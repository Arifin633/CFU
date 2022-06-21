using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using MonoMod.Utils;
using MonoMod.RuntimeDetour.HookGen;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.States;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Drawing;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.UI;
using Tiles = CFU.Tiles;
using Items = CFU.Items;

namespace ChadsFurnitureUpdated
{
    static class CFUHooks
    {
        public static void SetupHooks()
        {
            /* FIXME: The Hooks here should really be `Modify'ing instead of
               `Add'ing to these functions, but that's more complicated. */

            /* This hook allows the mod's Miracle Lily Pads to be drawn in
               the same manner as vanilla Lily Pads, that is, not being
               obstructed by water and reacting to ripples and waves. */
            HookEndpointManager.Add(typeof(Main).FindMethod("DrawTileInWater"), new Action<Vector2, int, int>((drawOffset, x, y) =>
            {
                if (Main.tile[x, y] != null && Main.tile[x, y].HasTile
                    && (Main.tile[x, y].TileType == ModContent.TileType<Tiles.MiracleLilyPads>() ||
                        Main.tile[x, y].TileType == 518))
                {
                    Main.instance.LoadTiles(Main.tile[x, y].TileType);
                    Tile tile = Main.tile[x, y];
                    int num = tile.LiquidAmount / 16;
                    num -= 3;
                    if (WorldGen.SolidTile(x, y - 1) && num > 8)
                        num = 8;

                    Rectangle value = new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16);
                    Main.spriteBatch.Draw(TextureAssets.Tile[tile.TileType].Value,
                                          new Vector2(x * 16, y * 16 - num) + drawOffset,
                                          value, Lighting.GetColor(x, y), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                }
            }));

            /* The `TileDrawing.Update' function updates both the
               internal WindGrid and the various wind counters.
               By hooking into this function and updating our own
               Grid/counters, we can ensure they will be in sync
               with their `TileDrawing' vanilla counterparts. */
            HookEndpointManager.Modify(typeof(TileDrawing).FindMethod("Update"), new Action<ILContext>((il) =>
            {
                var c = new ILCursor(il);
                c.EmitDelegate<Action>(() =>
                {
                    if (!Main.dedServ)
                    {
                        double num = Math.Abs(Main.WindForVisuals);
                        num = Utils.GetLerpValue(0.08f, 1.2f, (float)num, clamped: true);
                        CFUTileDraw.WindCounter += 1.0 / 420.0 + 1.0 / 420.0 * num * 5.0;
                        CFUTileDraw.WindCounterVine += 1.0 / 120.0 + 1.0 / 120.0 * num * 0.4000000059604645;
                        CFUTileDraw.EnsureWindGridSize();
                        CFUTileDraw.WindGrid.Update();
                    }
                });
            }));

            /* tModLoader has no pre-existing hook for `PreDrawTiles'.
               Thus to hook into this function is the most sensible way to make
               sure our array will get reset neither too early nor too late. */
            HookEndpointManager.Modify(typeof(TileDrawing).FindMethod("PreDrawTiles"), new Action<ILContext>((il) =>
            {
                var c = new ILCursor(il);
                c.GotoNext(MoveType.Before, i => i.MatchLdarg(0));
                c.EmitDelegate<Action>(() =>
                {
                    CFUTileDraw.SpecialPositionsCount[0] = 0;
                    CFUTileDraw.SpecialPositionsCount[1] = 0;
                    CFUTileDraw.SpecialPositionsCount[2] = 0;
                    CFUTileDraw.SpecialPositionsCount[3] = 0;
                    CFUTileDraw.SpecialPositionsCount[4] = 0;
                });
            }));

            /* The point in time a drawing function is called
               seems to be the sole determinant for drawing order.
               Therefore, to ensure our tiles' drawing order looks
               just like vanilla, we must hook into this function
               and draw our tiles at the same time as their equivalents.*/
            HookEndpointManager.Modify(typeof(TileDrawing).FindMethod("PostDrawTiles"), new Action<ILContext>((il) =>
            {
                var c = new ILCursor(il);
                c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawMultiTileVines"));
                c.EmitDelegate<Action>(() =>
                {
                    for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[0]; i++)
                        if (CFUTileDraw.SpecialPositionsCount[0] < 5000 && // Don't draw past the array size.
                            CFUTileDraw.SpecialPositions[0][i] != new Point()) // Don't draw empty coordinates.
                            CFUTileDraw.DrawHangingTile(CFUTileDraw.SpecialPositions[0][i]);
                });

                c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawMultiTileGrass"));
                c.EmitDelegate<Action>(() =>
                {
                    for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[2]; i++)
                        if (CFUTileDraw.SpecialPositionsCount[2] < 5000 && // Don't draw past the array size.
                            CFUTileDraw.SpecialPositions[2][i] != new Point()) // Don't draw empty coordinates.
                            CFUTileDraw.DrawRisingTile(CFUTileDraw.SpecialPositions[2][i]);
                });
                
                c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawVines"));
                c.EmitDelegate<Action>(() =>
                {
                    for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[1]; i++)
                        if (CFUTileDraw.SpecialPositionsCount[1] < 5000 && // Don't draw past the array size.
                            CFUTileDraw.SpecialPositions[1][i] != new Point()) // Don't draw empty coordinates.
                            CFUTileDraw.DrawHangingVine(CFUTileDraw.SpecialPositions[1][i]);
                });

                c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawReverseVines"));
                c.EmitDelegate<Action>(() =>
                {
                    for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[3]; i++)
                        if (CFUTileDraw.SpecialPositionsCount[3] < 5000 && // Don't draw past the array size.
                            CFUTileDraw.SpecialPositions[3][i] != new Point()) // Don't draw empty coordinates.
                            CFUTileDraw.DrawRisingVine(CFUTileDraw.SpecialPositions[3][i]);
                });
            }));

            /* The hook below allows the player to place Cobweb and Ivy
               blocks as long as they border any other tile (as opposed
               to bordering a solid tile, as is the usual condition).
               As these tiles aren't frame-important, I find this to be
               the only perceivable way to unconditionally decide where
               they may or may not be placed. */
            HookEndpointManager.Modify(typeof(Player).FindMethod("PlaceThing_Tiles_BlockPlacementForAssortedThings"), new Action<ILContext>((il) =>
            {
                var c = new ILCursor(il);
                c.Next = null;
                c.GotoPrev(MoveType.Before, i => i.MatchRet());
                c.EmitDelegate<Func<bool, bool>>(canPlace =>
                {
                    Player player = Main.LocalPlayer;
                    int type = player.inventory[player.selectedItem].type;
                    if (type == ModContent.ItemType<Items.Cobweb>() ||
                        type == ModContent.ItemType<Items.Ivy>())
                    {
                        return
                            /* Based on the placement code for the
                               Living Fire, Bubbles, and Smoke Blocks. */
                            (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].HasTile ||
                             Main.tile[Player.tileTargetX + 1, Player.tileTargetY].WallType > 0 ||
                             Main.tile[Player.tileTargetX - 1, Player.tileTargetY].HasTile ||
                             Main.tile[Player.tileTargetX - 1, Player.tileTargetY].WallType > 0 ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY + 1].HasTile ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY + 1].WallType > 0 ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY - 1].HasTile ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY - 1].WallType > 0);
                    } else return canPlace;
                });
            }));

            /* The following two hooks replace the sole two existing
               calls to `TileLoader.ContainerName' with calls to our
               own `CFU.ContainerName' (which see).
               This is done so different styles of the same tile
               type can have different default container names. */
            HookEndpointManager.Add(typeof(ChestUI).FindMethod("DrawName"), new Action<SpriteBatch>(spritebatch =>
            {
                Player player = Main.player[Main.myPlayer];
                string text = string.Empty;
                if (Main.editChest)
                {
                    text = Main.npcChatText;
                    Main.instance.textBlinkerCount++;
                    if (Main.instance.textBlinkerCount >= 20)
                    {
                        if (Main.instance.textBlinkerState == 0)
                        {
                            Main.instance.textBlinkerState = 1;
                        }
                        else
                        {
                            Main.instance.textBlinkerState = 0;
                        }
                        Main.instance.textBlinkerCount = 0;
                    }
                    if (Main.instance.textBlinkerState == 1)
                    {
                        text += "|";
                    }
                    Main.instance.DrawWindowsIMEPanel(new Vector2(120f, 518f));
                }
                else if (player.chest > -1)
                {
                    if (Main.chest[player.chest] == null)
                    {
                        Main.chest[player.chest] = new Chest();
                    }
                    Chest chest = Main.chest[player.chest];
                    if (chest.name != "")
                    {
                        text = chest.name;
                    }
                    else
                    {
                        Tile tile = Main.tile[player.chestX, player.chestY];
                        if (tile.TileType == 21)
                        {
                            text = Lang.chestType[tile.TileFrameX / 36].Value;
                        }
                        else if (tile.TileType == 467 && tile.TileFrameX / 36 == 4)
                        {
                            text = Lang.GetItemNameValue(3988);
                        }
                        else if (tile.TileType == 467)
                        {
                            text = Lang.chestType2[tile.TileFrameX / 36].Value;
                        }
                        else if (tile.TileType == 88)
                        {
                            text = Lang.dresserType[tile.TileFrameX / 54].Value;
                        }
                        else if (TileID.Sets.BasicChest[Main.tile[player.chestX, player.chestY].TileType] || TileID.Sets.BasicDresser[Main.tile[player.chestX, player.chestY].TileType])
                        {
                            text = CFUtils.ContainerName(player.chestX, player.chestY);
                        }
                    }
                }
                else if (player.chest == -2)
                {
                    text = Lang.inter[32].Value;
                }
                else if (player.chest == -3)
                {
                    text = Lang.inter[33].Value;
                }
                else if (player.chest == -4)
                {
                    text = Lang.GetItemNameValue(3813);
                }
                else if (player.chest == -5)
                {
                    text = Lang.GetItemNameValue(4076);
                }
                Color color = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
                color = Color.White * (1f - (255f - (float)(int)Main.mouseTextColor) / 255f * 0.5f);
                color.A = byte.MaxValue;
                Utils.WordwrapString(text, FontAssets.MouseText.Value, 200, 1, out var lineAmount);
                lineAmount++;
                for (int i = 0; i < lineAmount; i++)
                {
                    ChatManager.DrawColorCodedStringWithShadow(spritebatch, FontAssets.MouseText.Value, text, new Vector2(504f, Main.instance.invBottom + i * 26), color, 0f, Vector2.Zero, Vector2.One, -1f, 1.5f);
                }
            }));

            HookEndpointManager.Add(typeof(IngameFancyUI).FindMethod("OpenVirtualKeyboard"), new Action<int>(keyboardContext =>
            {
                IngameFancyUI.CoverNextFrame();
                Main.ClosePlayerChat();
                Main.chatText = "";
                SoundEngine.PlaySound(SoundID.MenuTick);
                string labelText = "";
                switch (keyboardContext)
                {
                    case 1:
                        Main.editSign = true;
                        labelText = Language.GetTextValue("UI.EnterMessage");
                        break;
                    case 2:
                        {
                            labelText = Language.GetTextValue("UI.EnterNewName");
                            Player player = Main.player[Main.myPlayer];
                            Main.npcChatText = Main.chest[player.chest].name;
                            Tile tile = Main.tile[player.chestX, player.chestY];
                            if (tile.TileType == 21)
                            {
                                Main.defaultChestName = Lang.chestType[tile.TileFrameX / 36].Value;
                            }
                            else if (tile.TileType == 467 && tile.TileFrameX / 36 == 4)
                            {
                                Main.defaultChestName = Lang.GetItemNameValue(3988);
                            }
                            else if (tile.TileType == 467)
                            {
                                Main.defaultChestName = Lang.chestType2[tile.TileFrameX / 36].Value;
                            }
                            else if (tile.TileType == 88)
                            {
                                Main.defaultChestName = Lang.dresserType[tile.TileFrameX / 54].Value;
                            }
                            if (tile.TileType >= 625 && (TileID.Sets.BasicChest[tile.TileType] || TileID.Sets.BasicDresser[tile.TileType]))
                            {
                                Main.defaultChestName = CFUtils.ContainerName(player.chestX, player.chestY);
                            }
                            if (Main.npcChatText == "")
                            {
                                Main.npcChatText = Main.defaultChestName;
                            }
                            Main.editChest = true;
                            break;
                        }
                }
                Main.clrInput();
                if (!IngameFancyUI.CanShowVirtualKeyboard(keyboardContext))
                {
                    return;
                }
                Main.inFancyUI = true;
                switch (keyboardContext)
                {
                    case 1:
                        Main.InGameUI.SetState(new UIVirtualKeyboard(labelText, Main.npcChatText, delegate
                        {
                            Main.SubmitSignText();
                            IngameFancyUI.Close();
                        }, delegate
                        {
                            Main.InputTextSignCancel();
                            IngameFancyUI.Close();
                        }, keyboardContext));
                        break;
                    case 2:
                        Main.InGameUI.SetState(new UIVirtualKeyboard(labelText, Main.npcChatText, delegate
                        {
                            ChestUI.RenameChestSubmit(Main.player[Main.myPlayer]);
                            IngameFancyUI.Close();
                        }, delegate
                        {
                            ChestUI.RenameChestCancel();
                            IngameFancyUI.Close();
                        }, keyboardContext));
                        break;
                }
                UILinkPointNavigator.GoToDefaultPage(1);
            }));
        }
    }
}
