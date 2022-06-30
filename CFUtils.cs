using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace ChadsFurnitureUpdated
{
    static class CFUtils
    {
        /* Shift the tile which [I, J] belongs to by SHIFTPIXELS.
           
           Note that tiles that have styles with differing heights
           or widths are not supported by this function.
           
           SHIFTY decides which axis the tile will be shifted on,
           false for the X axis and true for Y axis.

           If RESET is true, the tile will not be shifted but
           reset to its original frame, beginning at zero.
           If RESETTO has a non-zero value and RESET is true,
           the tile will be reset to this value instead of zero.

           If SKIPWIRE is true, `Wiring.SkipWire' will be called for each tile. */
        public static void ShiftTile(int i, int j, short shiftPixels = 0, bool shiftY = false, bool reset = false, bool skipWire = false, short resetTo = 0)
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

            short init = resetTo;
            short acc = init;

            if (!shiftY)
            {
                for (int y = (-1 * absy); y <= diffy; y++)
                {
                    for (int x = (-1 * absx); x <= diffx; x++)
                    {
                        if (skipWire)
                            Wiring.SkipWire(i + x, j + y);

                        if (reset)
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

                        if (reset)
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
        public static void ShiftTileX(int i, int j, short shiftPixels = 0, bool reset = false, bool skipWire = false, short resetTo = 0)
        {
            ShiftTile(i, j, shiftPixels, false, reset, skipWire, resetTo);
        }

        /* See `ShiftTile'. */
        public static void ShiftTileY(int i, int j, short shiftPixels = 0, bool reset = false, bool skipWire = false, short resetTo = 0)
        {
            ShiftTile(i, j, shiftPixels, true, reset, skipWire, resetTo);
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

        public static void SetupTileMerge(int type, bool mergeTo = true, bool mergeFrom = true)
        {
            /* This array is missing all 1.4 tiles. */
            int[] tiles =
                { TileID.Stone,
                  TileID.Grass,
                  TileID.Iron,
                  TileID.Copper,
                  TileID.Gold,
                  TileID.Silver,
                  TileID.Demonite,
                  TileID.CorruptGrass,
                  TileID.Ebonstone,
                  TileID.WoodBlock,
                  TileID.Meteorite,
                  TileID.GrayBrick,
                  TileID.RedBrick,
                  TileID.ClayBlock,
                  TileID.BlueDungeonBrick,
                  TileID.GreenDungeonBrick,
                  TileID.PinkDungeonBrick,
                  TileID.GoldBrick,
                  TileID.SilverBrick,
                  TileID.CopperBrick,
                  TileID.Sand,
                  TileID.Glass,
                  TileID.Obsidian,
                  TileID.Ash,
                  TileID.Hellstone,
                  TileID.Mud,
                  TileID.ObsidianBrick,
                  TileID.HellstoneBrick,
                  TileID.Cobalt,
                  TileID.Mythril,
                  TileID.HallowedGrass,
                  TileID.Adamantite,
                  TileID.Ebonsand,
                  TileID.Pearlsand,
                  TileID.Pearlstone,
                  TileID.PearlstoneBrick,
                  TileID.IridescentBrick,
                  TileID.Mudstone,
                  TileID.CobaltBrick,
                  TileID.MythrilBrick,
                  TileID.Silt,
                  TileID.ActiveStoneBlock,
                  TileID.InactiveStoneBlock,
                  TileID.DemoniteBrick,
                  TileID.CandyCaneBlock,
                  TileID.GreenCandyCaneBlock,
                  TileID.SnowBlock,
                  TileID.SnowBrick,
                  TileID.AdamantiteBeam,
                  TileID.SandstoneBrick,
                  TileID.EbonstoneBrick,
                  TileID.RedStucco,
                  TileID.YellowStucco,
                  TileID.GreenStucco,
                  TileID.GrayStucco,
                  TileID.Ebonwood,
                  TileID.RichMahogany,
                  TileID.Pearlwood,
                  TileID.RainbowBrick,
                  TileID.IceBlock,
                  TileID.BreakableIce,
                  TileID.CorruptIce,
                  TileID.HallowedIce,
                  TileID.Stalactite,
                  TileID.Tin,
                  TileID.Lead,
                  TileID.Tungsten,
                  TileID.Platinum,
                  TileID.TinBrick,
                  TileID.TungstenBrick,
                  TileID.PlatinumBrick,
                  TileID.GreenMoss,
                  TileID.BrownMoss,
                  TileID.RedMoss,
                  TileID.BlueMoss,
                  TileID.PurpleMoss,
                  TileID.CactusBlock,
                  TileID.MushroomBlock,
                  TileID.LivingWood,
                  TileID.SlimeBlock,
                  TileID.BoneBlock,
                  TileID.FleshBlock,
                  TileID.RainCloud,
                  TileID.FrozenSlimeBlock,
                  TileID.Asphalt,
                  TileID.CrimsonGrass,
                  TileID.FleshIce,
                  TileID.Sunplate,
                  TileID.Crimstone,
                  TileID.Crimtane,
                  TileID.IceBrick,
                  TileID.Shadewood,
                  TileID.Chlorophyte,
                  TileID.Palladium,
                  TileID.Orichalcum,
                  TileID.Titanium,
                  TileID.Slush,
                  TileID.Hive,
                  TileID.LihzahrdBrick,
                  TileID.HoneyBlock,
                  TileID.CrispyHoneyBlock,
                  TileID.Crimsand,
                  TileID.PalladiumColumn,
                  TileID.BubblegumBlock,
                  TileID.Titanstone,
                  TileID.PumpkinBlock,
                  TileID.HayBlock,
                  TileID.SpookyWood,
                  TileID.AmethystGemsparkOff,
                  TileID.TopazGemsparkOff,
                  TileID.SapphireGemsparkOff,
                  TileID.EmeraldGemsparkOff,
                  TileID.RubyGemsparkOff,
                  TileID.DiamondGemsparkOff,
                  TileID.AmberGemsparkOff,
                  TileID.AmethystGemspark,
                  TileID.TopazGemspark,
                  TileID.SapphireGemspark,
                  TileID.EmeraldGemspark,
                  TileID.RubyGemspark,
                  TileID.DiamondGemspark,
                  TileID.AmberGemspark,
                  TileID.Cog,
                  TileID.StoneSlab,
                  TileID.SandStoneSlab,
                  TileID.CopperPlating,
                  TileID.DynastyWood,
                  TileID.BorealWood,
                  TileID.PalmWood,
                  TileID.TinPlating,
                  TileID.Waterfall,
                  TileID.Lavafall,
                  TileID.Confetti,
                  TileID.ConfettiBlack,
                  TileID.Honeyfall,
                  TileID.ChlorophyteBrick,
                  TileID.CrimtaneBrick,
                  TileID.ShroomitePlating,
                  TileID.MartianConduitPlating,
                  TileID.MarbleBlock,
                  TileID.Marble,
                  TileID.Granite,
                  TileID.GraniteBlock,
                  TileID.MeteoriteBrick,
                  TileID.PinkSlimeBlock,
                  TileID.LivingMahogany,
                  TileID.CrystalBlock,
                  TileID.Sandstone,
                  TileID.HardenedSand,
                  TileID.CorruptHardenedSand,
                  TileID.CrimsonHardenedSand,
                  TileID.CorruptSandstone,
                  TileID.CrimsonSandstone,
                  TileID.HallowHardenedSand,
                  TileID.HallowSandstone,
                  TileID.DesertFossil,
                  TileID.FossilOre,
                  TileID.LunarOre,
                  TileID.LunarBrick,
                  TileID.LunarBlockSolar,
                  TileID.LunarBlockVortex,
                  TileID.LunarBlockNebula,
                  TileID.LunarBlockStardust,
                  TileID.TeamBlockRed,
                  TileID.TeamBlockGreen,
                  TileID.TeamBlockBlue,
                  TileID.TeamBlockYellow,
                  TileID.TeamBlockPink,
                  TileID.TeamBlockWhite,
                  TileID.SandFallBlock,
                  TileID.SnowFallBlock };

            foreach (int tile in tiles)
            {
                if (mergeFrom)
                    Main.tileMerge[type][tile] = true;
                if (mergeTo)
                    Main.tileMerge[tile][type] = true;
            }
        }
    }
}
