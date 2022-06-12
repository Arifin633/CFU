using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour.HookGen;
using MonoMod.Utils;
using Terraria;
using Terraria.GameContent.UI.States;
using Terraria.UI;
using Terraria.UI.Gamepad;
using Terraria.UI.Chat;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.Localization;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    static class CFUtils
    {
        /* Shift the tile which [I, J] belong to by PIXELHEIGHT pixels. */
        public static void ShiftTileY(int i, int j, int width, int height, short pixelHeight, bool reset = false, bool skipwire = false)
        {
            /* Theoretically we could figure out WIDTH, HEIGHT and PIXELHEIGHT
               just from the Tile coordinates, but it's just as easy for the
               caller itself to input those values directly and save us some
               performance and complexity. */
            int absy = Main.tile[i, j].TileFrameY / 18;
            int absx = Main.tile[i, j].TileFrameX / 18;
            while (absy >= height) { absy -= height; }
            while (absx >= width) { absx -= width; }

            int diffy = (height - 1) - absy;
            int diffx = (width - 1) - absx;

            short acc = 0;
            for (int x = (-1 * absx); x <= diffx; x++)
            {
                for (int y = (-1 * absy); y <= diffy; y++)
                {
                    if (skipwire)
                        Wiring.SkipWire(i + x, j + y);

                    if (reset)
                    {
                        Main.tile[i + x, j + y].TileFrameY = acc;
                        if ((pixelHeight - acc) > 18 && 36 > (pixelHeight - acc))
                            acc += (short)(pixelHeight - acc);
                        else
                            acc += 18;
                    }
                    else { Main.tile[i + x, j + y].TileFrameY += pixelHeight; }
                }
                acc = 0;
            }
        }

        public static void ShiftTileX(int i, int j, int width, int height, short pixelWidth, bool reset = false, bool skipwire = false)
        {
            int absy = Main.tile[i, j].TileFrameY / 18;
            int absx = Main.tile[i, j].TileFrameX / 18;
            while (absy >= height) { absy -= height; }
            while (absx >= width) { absx -= width; }

            int diffy = (height - 1) - absy;
            int diffx = (width - 1) - absx;

            short acc = 0;
            for (int y = (-1 * absy); y <= diffy; y++)
            {
                for (int x = (-1 * absx); x <= diffx; x++)
                {
                    if (skipwire)
                        Wiring.SkipWire(i + x, j + y);

                    if (reset)
                    {
                        Main.tile[i + x, j + y].TileFrameX = acc;
                        if ((pixelWidth - acc) > 18 && 36 > (pixelWidth - acc))
                            acc += (short)(pixelWidth - acc);
                        else
                            acc += 18;
                    }
                    else { Main.tile[i + x, j + y].TileFrameX += pixelWidth; }

                }
                acc = 0;
            }
        }

        public static void ForgeDrawSmoke(int i, int j, SpriteBatch spriteBatch, string smoke, int smokeX, int smokeY, int Type)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            if (tile.TileFrameY % 56 == 0 && tile.TileFrameX % 72 == 0)
            {
                /* The size of the area in which tiles are considered an
                   obstruction is rather large, but that means we can safely
                   use it for all kinds of forges without change. */
                bool obstructed = false;
                for (int x = 1; x <= 3; x++)
                    for (int y = 1; y <= 2; y++)
                        if (WorldGen.SolidTile(i + x, j - y))
                            obstructed = true;

                if (!obstructed)
                    spriteBatch.Draw(
                        ModContent.Request<Texture2D>("CFU/Textures/Tiles/Stations/" + smoke).Value,
                        new Vector2(i * 16 + smokeX - (int)Main.screenPosition.X, j * 16 - smokeY - (int)Main.screenPosition.Y) + zero,
                        new Rectangle(Main.tileFrame[Type] * 32, 0, 30, 26),
                        Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }

        public static void DrawFlame(int i, int j, SpriteBatch spriteBatch, string flame)
        {
            DrawFlame(i, j, spriteBatch, flame, false);
        }

        public static void DrawFlame(int i, int j, SpriteBatch spriteBatch, string flame, bool torch)
        {
            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            int frameX = (torch) ? (Main.tile[i, j].TileFrameX + 2) : Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            int offsetY = (torch && (WorldGen.SolidTile(i, j - 1))) ? 2 : 0;
            for (int k = 0; k < 7; k++)
            {
                float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>("CFU/Textures/Tiles/Furniture/" + flame).Value,
                    new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero,
                    new Rectangle(frameX, frameY, 16, 18), new Color(100, 100, 100, 0), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }

        public static void PrintTime()
        {
            double time = Main.dayTime ? Main.time : (Main.time + 54000.0);
            time = (time / 86400.0 * 24.0) - 19.5;
            if (time < 0.0) { time += 24.0; }

            double minutesNum = (int)((time % 1) * 60.0);
            string minutes = minutesNum.ToString() ?? "";

            if (minutesNum < 10.0)
                minutes = "0" + minutes;

            int hours = (int)time;
            string period = (hours > 12.0) ? "AM" : "PM";

            if (hours > 12)
                hours -= 12;
            else if (hours == 0)
                hours = 12;

            Main.NewText($"Time: {hours}:{minutes} {period}", 255, 240, 20);
        }

        public static void OpenChest(int i, int j, int width)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % width));
            int top = (tile.TileFrameY % 38 == 0) ? j : (j - 1);

            Main.CancelClothesWindow(quiet: true);
            Main.mouseRightRelease = false;
            Main.npcChatCornerItem = 0;
            Main.npcChatText = "";
            player.CloseSign();
            player.SetTalkNPC(-1);

            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
            }

            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                player.editedChestName = false;
            }

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (left == player.chestX && top == player.chestY && player.chest >= 0)
                {
                    player.chest = -1;
                    Recipe.FindRecipes();
                    SoundEngine.PlaySound(SoundID.MenuClose);
                }
                else
                {
                    NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
                    Main.stackSplit = 600;
                }
            }
            else
            {
                int chest = Chest.FindChest(left, top);
                if (chest >= 0)
                {
                    Main.stackSplit = 600;
                    if (chest == player.chest)
                    {
                        player.chest = -1;
                        SoundEngine.PlaySound(SoundID.MenuClose);
                    }
                    else
                    {
                        SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                        player.chest = chest;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        player.chestX = left;
                        player.chestY = top;
                    }
                    Recipe.FindRecipes();
                }
            }
        }

    }

    public class CFU : Mod
    {
        static string ContainerName(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileType == ModContent.TileType<Tiles.Chests>())
                return Tiles.Chests.Names[(tile.TileFrameX / 36)];
            else if (tile.TileType == ModContent.TileType<Tiles.Dressers>())
                return Tiles.Dressers.Names[(tile.TileFrameY / 36)];
            else return TileLoader.ContainerName(tile.TileType);
        }

        public override void PostSetupContent()
        {
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
                            text = ContainerName(player.chestX, player.chestY);
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
                SoundEngine.PlaySound(12);
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
                                Main.defaultChestName = ContainerName(player.chestX, player.chestY);
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
