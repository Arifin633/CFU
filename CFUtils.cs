using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
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
                    else
                    {
                        Main.tile[i + x, j + y].TileFrameY += pixelHeight;
                    }

                    if (Main.netMode == NetmodeID.MultiplayerClient)
                        NetMessage.SendTileSquare(-1, (i + x), (j + y));
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
                    else
                    {
                        Main.tile[i + x, j + y].TileFrameX += pixelWidth;
                    }
                    
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                        NetMessage.SendTileSquare(-1, (i + x), (j + y));

                }
                acc = 0;
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

        public static string ContainerName(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileType == ModContent.TileType<Tiles.Chests>())
                return Tiles.Chests.Names[(tile.TileFrameX / 36)];
            else if (tile.TileType == ModContent.TileType<Tiles.Dressers>())
                return Tiles.Dressers.Names[(tile.TileFrameX / 54)];
            else if (tile.TileType == ModContent.TileType<Tiles.Cabinets>())
                return Tiles.Cabinets.Names[(tile.TileFrameX / 36)];
            /* Since we fall back to using the original TileLoader function in
               all but the specific cases that should return a different value,
               this function should never cause any problems. */
            else return TileLoader.ContainerName(tile.TileType);
        }

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
