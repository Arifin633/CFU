using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    static class CFUtils
    {
        /* Shift the tile which [I, J] belongs to by SHIFTPIXELS.
           
           Note that tiles that have styles with differing heights
           or widths are not supported by this function.
           
           SHIFTY decides which axis the tile will be shifted on,
           false for the X axis and true for Y axis.

           If SET is true, the tile frame will not be shifted
           but set, beginning at SHIFTPIXELS (zero by default).

           If SKIPWIRE is true, `Wiring.SkipWire' will be called for each tile. */
        public static void ShiftTile(int i, int j, short shiftPixels = 0, bool shiftY = false, bool set = false, bool skipWire = false)
        {
            var data = TileObjectData.GetTileData(Main.tile[i, j].TileType, 0);

            int width = data.Width;
            int height = data.Height;

            int padding = data.CoordinatePadding;
            int pixelHeightStep = data.CoordinateHeights[0] + padding;
            var pixelLastHeightStep = data.CoordinateHeights[(data.CoordinateHeights.Length - 1)] + padding;

            int pixelDiff = (pixelLastHeightStep - pixelHeightStep);
            int pixelWidthStep = data.CoordinateWidth + padding;

            int absy = ((pixelDiff != 0 && (Main.tile[i, j].TileFrameY % pixelDiff) != 0) ?
                        (Main.tile[i, j].TileFrameY - pixelDiff) :
                        (Main.tile[i, j].TileFrameY))
                / pixelHeightStep;
            int absx = Main.tile[i, j].TileFrameX / pixelWidthStep;
            while (absy >= height) { absy -= height; }
            while (absx >= width) { absx -= width; }

            int diffy = (height - 1) - absy;
            int diffx = (width - 1) - absx;

            short init = shiftPixels;
            short acc = init;

            if (!shiftY)
            {
                for (int y = (-1 * absy); y <= diffy; y++)
                {
                    for (int x = (-1 * absx); x <= diffx; x++)
                    {
                        if (skipWire)
                            Wiring.SkipWire(i + x, j + y);

                        if (set)
                        {
                            Main.tile[i + x, j + y].TileFrameX = acc;
                            acc += (short)pixelWidthStep;
                        }
                        else
                        {
                            Main.tile[i + x, j + y].TileFrameX += shiftPixels;
                        }

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.SendTileSquare(-1, (i + x), (j + y));

                    }
                    acc = init;
                }
            }
            else
            {
                for (int x = (-1 * absx); x <= diffx; x++)
                {
                    for (int y = (-1 * absy); y <= diffy; y++)
                    {
                        if (skipWire)
                            Wiring.SkipWire(i + x, j + y);

                        if (set)
                        {
                            Main.tile[i + x, j + y].TileFrameY = acc;
                            acc += (short)pixelHeightStep;
                        }
                        else
                        {
                            Main.tile[i + x, j + y].TileFrameY += shiftPixels;
                        }

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.SendTileSquare(-1, (i + x), (j + y));
                    }
                    acc = init;
                }
            }
        }

        /* See `ShiftTile'. */
        public static void ShiftTileX(int i, int j, short shiftPixels = 0, bool set = false, bool skipWire = false)
        {
            ShiftTile(i, j, shiftPixels, false, set, skipWire);
        }

        /* See `ShiftTile'. */
        public static void ShiftTileY(int i, int j, short shiftPixels = 0, bool set = false, bool skipWire = false)
        {
            ShiftTile(i, j, shiftPixels, true, set, skipWire);
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

        public static Terraria.Recipe.ConsumeItemCallback Print = delegate (Recipe recipe, int type, ref int amount) { amount = 0; };

        /* Makes so TYPE will merge with other tiles,
           but other tiles won't merge with TYPE. */
        public static void SetupOneSidedTileMerge(int type)
        {
            for (int i = 0; i < TileID.Count; i++)
            {
                if (Main.tileSolid[i] || TileID.Sets.IsBeam[i])
                    Main.tileMerge[type][i] = true;
            }

            int[] moddedTiles =
                { ModContent.TileType<Tiles.GraniteBrick>(),
                  ModContent.TileType<Tiles.GranitePillar>(),
                  ModContent.TileType<Tiles.LeadGlass>(),
                  ModContent.TileType<Tiles.LimestoneBrick>(),
                  ModContent.TileType<Tiles.LimestoneFrieze>(),
                  ModContent.TileType<Tiles.LimestoneSlabArch>(),
                  ModContent.TileType<Tiles.LimestoneSlab>(),
                  ModContent.TileType<Tiles.MarblePillar>(),
                  ModContent.TileType<Tiles.MarbleBrick>(),
                  ModContent.TileType<Tiles.OrganPipe>(),
                  ModContent.TileType<Tiles.SandPillar>(),
                  ModContent.TileType<Tiles.SandstoneBrick>(),
                  ModContent.TileType<Tiles.SandstonePillar>(),
                  ModContent.TileType<Tiles.Shingles>(),
                  ModContent.TileType<Tiles.StoneFrieze>(),
                  ModContent.TileType<Tiles.StonePillar>() };
            
            foreach (int tile in moddedTiles)
            {
                Main.tileMerge[type][tile] = true;
            }
        }

        /* Set all height related fields of ELT to PIXEL. */
        public static void SetHeight(UIElement elt, float pixel)
        {
            elt.Height.Set(pixel, 0);
            elt.MaxHeight.Set(pixel, 0);
            elt.MinHeight.Set(pixel, 0);
        }

        /* Set all width related fields of ELT to PIXEL. */
        public static void SetWidth(UIElement elt, float pixel)
        {
            elt.Width.Set(pixel, 0);
            elt.MaxWidth.Set(pixel, 0);
            elt.MinWidth.Set(pixel, 0);
        }
    }
}
