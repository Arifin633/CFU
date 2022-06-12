using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Utils;
using MonoMod.RuntimeDetour.HookGen;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.States;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.UI;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    static class CFUHooks
    {
        public static void SetupHooks()
        {
            /* FIXME: The Hooks here should really be `Modify'ing instead of
             `Add'ing to these functions, but that's more complicated. */

            /* This Hook allows the mod's Miracle Lily Pads to be drawn in
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

            /* The following two hooks replace the sole two existing
               calls to `TileLoader.ContainerName' with calls to our
               own `CFU.ContainerName' (which see). */
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
