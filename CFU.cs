using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;

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

        public static int ChestAfterPlacementHook(int x, int y, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            Tile tile = Main.tile[x, y];
            Point16 baseCoords = new Point16(x, y);
            TileObjectData.OriginToTopLeft(type, style, ref baseCoords);
            int num = Chest.FindEmptyChest(baseCoords.X, baseCoords.Y);
            if (num == -1)
            {
                return -1;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Chest chest = new Chest();
                chest.x = baseCoords.X;
                chest.y = baseCoords.Y;
                for (int i = 0; i < 40; i++)
                {
                    chest.item[i] = new Item();
                }

                /* TODO: Add this to the netcode branch. */
                string name = "";
                int frame = TileID.Sets.BasicDresser[type] ? tile.TileFrameY : tile.TileFrameX;
                switch (frame / 36)
                {
                    case 0:
                        name = "Princess";
                        break;
                    case 1:
                        name = "Mystical";
                        break;
                    case 2:
                        name = "Royal";
                        break;
                    case 3:
                        name = "Sandstone";
                        break;
                }
                if (TileID.Sets.BasicDresser[type])
                    name += " Dresser";
                else if (frame / 36 == 3)
                    name += " Urn";
                else
                    name += " Chest";

                chest.name = name;
                Main.chest[num] = chest;
            }
            else
            {
                if (TileID.Sets.BasicChest[type])
                {
                    NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, 100, x, y, style, 0, type);
                }
                else if (TileID.Sets.BasicDresser[type])
                {
                    NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, 102, x, y, style, 0, type);
                }
            }
            return num;
        }
    }

    public class CFU : Mod
    {

    }
}
