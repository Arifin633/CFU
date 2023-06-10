using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated;

public static class CFUTileWand
{
    public static FlexibleTileWand BagCattails = CreateWandCattails(); /*!*/
    public static FlexibleTileWand BagFlowers = CreateWandFlowers();
    public static FlexibleTileWand BagGrass = CreateWandGrass();
    public static FlexibleTileWand BagHerbs = CreateWandHerbs();
    public static FlexibleTileWand BagLilyPads = CreateWandLilyPads();
    public static FlexibleTileWand BagMushrooms = CreateWandMushrooms();
    public static FlexibleTileWand BagOasisVegetation = CreateWandOasisVegetation();
    public static FlexibleTileWand BagSeaOats = CreateWandSeaOats();
    public static FlexibleTileWand BagSeaweed = CreateWandSeaweed(); /*!*/
    public static FlexibleTileWand BagVines = CreateWandVines(); /*!*/

    public static FlexibleTileWand Pots = CreateWandPots();

    public static FlexibleTileWand Stalactites = CreateWandStalactites();
    public static FlexibleTileWand Stalagmites = CreateWandStalagmites();

    /* Vanilla's `AddVariations_ByRow' assumes that every row has
       the same width (namely, the same value as `variationsPerRow'.
       This function has an additional argument, `rowLength',
       to demarcate the largest row.  */
    public static void AddVariationsByRowVariable(FlexibleTileWand wand, int itemType, int tileIdToPlace, int rowLength, int variationsPerRow, params int[] rows)
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < variationsPerRow; j++)
            {
                int tileStyleToPlace = rows[i] * rowLength + j;
                wand.AddVariation(itemType, tileIdToPlace, tileStyleToPlace);
            }
        }
    }

    public static FlexibleTileWand CreateWandCattails()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int cat = ModContent.TileType<Tiles.MiracleCattails>();
        wand.AddVariations(ItemID.GrassSeeds, cat, 1, 2, 3, 6, 7, 8);
        wand.AddVariations(ItemID.JungleGrassSeeds, cat, 10, 11, 12, 15, 16, 17);
        wand.AddVariations(ItemID.HallowedSeeds, cat, 19, 20, 21, 24, 25, 26);
        wand.AddVariations(ItemID.CrimsonSeeds, cat, 28, 29, 30, 33, 34, 35);
        wand.AddVariations(ItemID.CorruptSeeds, cat, 37, 38, 39, 42, 43, 44);
        wand.AddVariations(ItemID.GlowingMushroom, cat, 46, 47, 48, 51, 52, 53);
        return wand;
    }

    public static FlexibleTileWand CreateWandFlowers()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int shortFlowers = ModContent.TileType<Tiles.MiracleShortPlants>();
        int tallFlowers = ModContent.TileType<Tiles.MiracleTallPlants>();
        int abigailFlower = ModContent.TileType<Tiles.MiracleAbigailsFlower>();
        int glowTulip = ModContent.TileType<Tiles.MiracleGlowTulip>();

        /* Yellow Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketYellow, shortFlowers, 32, 14, 1);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketYellow, tallFlowers, 20, 14, 2);

        /* White Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketWhite, shortFlowers, 32, 16, 2);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketWhite, tallFlowers, 20, 16, 1);

        /* Red Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketRed, shortFlowers, 32, 14, 3);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketRed, tallFlowers, 20, 14, 3);

        /* Blue Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketBlue, shortFlowers, 32, 6, 4);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketBlue, tallFlowers, 20, 6, 6);

        /* Purple Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketMagenta, shortFlowers, 32, 14, 5);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketMagenta, tallFlowers, 20, 14, 4);

        /* Pink Flowers */
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketPink, shortFlowers, 32, 12, 6);
        AddVariationsByRowVariable(wand, ItemID.FlowerPacketPink, tallFlowers, 20, 12, 5);

        /* Corruption Flowers */
        AddVariationsByRowVariable(wand, ItemID.CorruptSeeds, shortFlowers, 32, 32, 8);

        /* Jungle Flowers */
        AddVariationsByRowVariable(wand, ItemID.JungleGrassSeeds, shortFlowers, 32, 32, 10);
        AddVariationsByRowVariable(wand, ItemID.JungleGrassSeeds, tallFlowers, 20, 20, 8);

        /* Hallowed Flowers */
        AddVariationsByRowVariable(wand, ItemID.HallowedSeeds, shortFlowers, 32, 32, 13);
        AddVariationsByRowVariable(wand, ItemID.HallowedSeeds, tallFlowers, 20, 10, 10);

        /* Crimson Flowers */
        AddVariationsByRowVariable(wand, ItemID.CrimsonSeeds, shortFlowers, 32, 14, 15);

        /* Ash Grass Flowers */
        AddVariationsByRowVariable(wand, ItemID.AshGrassSeeds, shortFlowers, 32, 10, 21);

        /* Abigail's Flower */
        wand.AddVariations(ItemID.AbigailsFlower, abigailFlower, 0, 1);

        /* Glow Tulip */
        wand.AddVariations(ItemID.GlowTulip, glowTulip, 0, 1);

        return wand;
    }

    public static FlexibleTileWand CreateWandGrass()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int shortGrass = ModContent.TileType<Tiles.MiracleShortPlants>();
        int tallGrass = ModContent.TileType<Tiles.MiracleTallPlants>();

        /* Forest Grass */
        AddVariationsByRowVariable(wand, ItemID.GrassSeeds, shortGrass, 32, 12, 0);
        AddVariationsByRowVariable(wand, ItemID.GrassSeeds, tallGrass, 20, 12, 0);

        /* Corruption Grass */
        AddVariationsByRowVariable(wand, ItemID.CorruptSeeds, shortGrass, 32, 12, 7);

        /* Jungle Grass */
        AddVariationsByRowVariable(wand, ItemID.JungleGrassSeeds, shortGrass, 32, 12, 9);
        AddVariationsByRowVariable(wand, ItemID.JungleGrassSeeds, tallGrass, 20, 12, 7);

        /* Hallowed Grass */
        AddVariationsByRowVariable(wand, ItemID.HallowedSeeds, shortGrass, 32, 12, 12);
        AddVariationsByRowVariable(wand, ItemID.HallowedSeeds, tallGrass, 20, 6, 9);

        /* Crimson Grass */
        AddVariationsByRowVariable(wand, ItemID.CrimsonSeeds, shortGrass, 32, 30, 14);

        /* Ash Grass */
        AddVariationsByRowVariable(wand, ItemID.AshGrassSeeds, shortGrass, 32, 12, 20);

        return wand;
    }

    public static FlexibleTileWand CreateWandHerbs()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int herbs = ModContent.TileType<Tiles.MiracleHerbs>();
        wand.AddVariations_ByRow(ItemID.Daybloom, herbs, 3, 0);
        wand.AddVariations_ByRow(ItemID.DaybloomSeeds, herbs, 3, 7);
        wand.AddVariations_ByRow(ItemID.Moonglow, herbs, 3, 1);
        wand.AddVariations_ByRow(ItemID.MoonglowSeeds, herbs, 3, 8);
        wand.AddVariations_ByRow(ItemID.Blinkroot, herbs, 3, 2);
        wand.AddVariations_ByRow(ItemID.BlinkrootSeeds, herbs, 3, 9);
        wand.AddVariations_ByRow(ItemID.Deathweed, herbs, 3, 3);
        wand.AddVariations_ByRow(ItemID.DeathweedSeeds, herbs, 3, 10);
        wand.AddVariations_ByRow(ItemID.Waterleaf, herbs, 3, 4);
        wand.AddVariations_ByRow(ItemID.WaterleafSeeds, herbs, 3, 11);
        wand.AddVariations_ByRow(ItemID.Fireblossom, herbs, 3, 5);
        wand.AddVariations_ByRow(ItemID.FireblossomSeeds, herbs, 3, 12);
        wand.AddVariations_ByRow(ItemID.Shiverthorn, herbs, 3, 6);
        wand.AddVariations_ByRow(ItemID.ShiverthornSeeds, herbs, 3, 13);
        return wand;
    }

    public static FlexibleTileWand CreateWandLilyPads()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int lily = ModContent.TileType<Tiles.MiracleLilyPads>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, lily, 18, 0);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, lily, 18, 1);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, lily, 18, 2);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, lily, 18, 3);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, lily, 18, 4);
        return wand;
    }

    public static FlexibleTileWand CreateWandMushrooms()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int mushrooms = ModContent.TileType<Tiles.MiracleShortPlants>();
        AddVariationsByRowVariable(wand, ItemID.Mushroom, mushrooms, 32, 1, 16);
        AddVariationsByRowVariable(wand, ItemID.VileMushroom, mushrooms, 32, 1, 17);
        AddVariationsByRowVariable(wand, ItemID.JungleSpores, mushrooms, 32, 1, 18);
        AddVariationsByRowVariable(wand, ItemID.ViciousMushroom, mushrooms, 32, 1, 19);
        AddVariationsByRowVariable(wand, ItemID.GlowingMushroom, mushrooms, 32, 10, 11);
        return wand;
    }

    public static FlexibleTileWand CreateWandOasisVegetation()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int oasis = ModContent.TileType<Tiles.MiracleOasisVegetation>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, oasis, 9, 0);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, oasis, 9, 1);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, oasis, 9, 2);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, oasis, 9, 3);
        return wand;
    }

    public static FlexibleTileWand CreateWandSeaOats()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int oats = ModContent.TileType<Tiles.MiracleSeaOats>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, oats, 15, 0);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, oats, 15, 1);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, oats, 15, 2);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, oats, 15, 3);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, oats, 15, 4);
        return wand;
    }

    public static FlexibleTileWand CreateWandSeaweed()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int seaweed = ModContent.TileType<Tiles.MiracleSeaweed>();
        wand.AddVariations(ItemID.GrassSeeds, seaweed, 0, 1);
        AddVariationsByRowVariable(wand, ItemID.GrassSeeds, seaweed, 14, 10, 2);
        return wand;
    }

    public static FlexibleTileWand CreateWandVines()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int vine = ModContent.TileType<Tiles.MiracleVines>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, vine, 24, 0);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, vine, 24, 1);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, vine, 24, 2);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, vine, 24, 3);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, vine, 24, 4);
        wand.AddVariations_ByRow(ItemID.GlowingMushroom, vine, 24, 5);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, vine, 24, 7);
        wand.AddVariations_ByRow(ItemID.AshGrassSeeds, vine, 24, 8);
        return wand;
    }

    public static FlexibleTileWand CreateWandPots()
    {
        /* Adapted from `ForModders_AddPotsToWand' */
        FlexibleTileWand wand = new FlexibleTileWand();
        int pots = TileID.PotsEcho;
        wand.AddVariations_ByRow(ItemID.ClayBlock, pots, 3, 0, 1, 2, 3);
        wand.AddVariations_ByRow(ItemID.IceBlock, pots, 3, 4, 5, 6);
        wand.AddVariations_ByRow(ItemID.MudBlock, pots, 3, 7, 8, 9);
        wand.AddVariations_ByRow(ItemID.Bone, pots, 3, 10, 11, 12);
        wand.AddVariations_ByRow(ItemID.Obsidian, pots, 3, 13, 14, 15);
        wand.AddVariations_ByRow(ItemID.EbonstoneBlock, pots, 3, 16, 17, 18);
        wand.AddVariations_ByRow(ItemID.Cobweb, pots, 3, 19, 20, 21);
        wand.AddVariations_ByRow(ItemID.CrimstoneBlock, pots, 3, 22, 23, 24);
        wand.AddVariations_ByRow(ItemID.SandstoneBrick, pots, 3, 25, 26, 27);
        wand.AddVariations_ByRow(ItemID.LihzahrdBrick, pots, 3, 28, 29, 30);
        wand.AddVariations_ByRow(ItemID.Marble, pots, 3, 31, 32, 33);
        wand.AddVariations_ByRow(ItemID.SandstoneBrick, pots, 3, 34, 35, 36);
        return wand;
    }

    public static FlexibleTileWand CreateWandStalactites()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int stalac = ModContent.TileType<Tiles.Stalactites>();
        int stalacsmall = ModContent.TileType<Tiles.SmallStalactites>();
        wand.AddVariations(ItemID.StoneBlock, stalac, 0, 1, 2);
        wand.AddVariations(ItemID.PearlstoneBlock, stalac, 3, 4, 5);
        wand.AddVariations(ItemID.EbonstoneBlock, stalac, 6, 7, 8);
        wand.AddVariations(ItemID.CrimstoneBlock, stalac, 9, 10, 11);
        wand.AddVariations(ItemID.Sandstone, stalac, 12, 13, 14);
        wand.AddVariations(ItemID.GraniteBlock, stalac, 15, 16, 17);
        wand.AddVariations(ItemID.MarbleBlock, stalac, 18, 19, 20);
        wand.AddVariations(ItemID.Cobweb, stalac, 21, 22, 23);
        wand.AddVariations(ItemID.PinkIceBlock, stalac, 24, 25, 26);
        wand.AddVariations(ItemID.PurpleIceBlock, stalac, 27, 28, 29);
        wand.AddVariations(ItemID.RedIceBlock, stalac, 30, 31, 32);
        wand.AddVariations(ItemID.IceBlock, stalac, 33, 34, 35);

        wand.AddVariations(ItemID.StoneBlock, stalacsmall, 0, 1, 2);
        wand.AddVariations(ItemID.PearlstoneBlock, stalacsmall, 3, 4, 5);
        wand.AddVariations(ItemID.EbonstoneBlock, stalacsmall, 6, 7, 8);
        wand.AddVariations(ItemID.CrimstoneBlock, stalacsmall, 9, 10, 11);
        wand.AddVariations(ItemID.Sandstone, stalacsmall, 12, 13, 14);
        wand.AddVariations(ItemID.GraniteBlock, stalacsmall, 15, 16, 17);
        wand.AddVariations(ItemID.MarbleBlock, stalacsmall, 18, 19, 20);
        wand.AddVariations(ItemID.Hive, stalacsmall, 21, 22, 23);
        wand.AddVariations(ItemID.PinkIceBlock, stalacsmall, 24, 25, 26);
        wand.AddVariations(ItemID.PurpleIceBlock, stalacsmall, 27, 28, 29);
        wand.AddVariations(ItemID.RedIceBlock, stalacsmall, 30, 31, 32);
        wand.AddVariations(ItemID.IceBlock, stalacsmall, 33, 34, 35);
        return wand;
    }

    public static FlexibleTileWand CreateWandStalagmites()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int stalag = ModContent.TileType<Tiles.Stalagmites>();
        int stalagsmall = ModContent.TileType<Tiles.SmallStalagmites>();
        wand.AddVariations(ItemID.StoneBlock, stalag, 0, 1, 2);
        wand.AddVariations(ItemID.PearlstoneBlock, stalag, 3, 4, 5);
        wand.AddVariations(ItemID.EbonstoneBlock, stalag, 6, 7, 8);
        wand.AddVariations(ItemID.CrimstoneBlock, stalag, 9, 10, 11);
        wand.AddVariations(ItemID.Sandstone, stalag, 12, 13, 14);
        wand.AddVariations(ItemID.GraniteBlock, stalag, 15, 16, 17);
        wand.AddVariations(ItemID.MarbleBlock, stalag, 18, 19, 20);

        wand.AddVariations(ItemID.StoneBlock, stalagsmall, 0, 1, 2);
        wand.AddVariations(ItemID.PearlstoneBlock, stalagsmall, 3, 4, 5);
        wand.AddVariations(ItemID.EbonstoneBlock, stalagsmall, 6, 7, 8);
        wand.AddVariations(ItemID.CrimstoneBlock, stalagsmall, 9, 10, 11);
        wand.AddVariations(ItemID.Sandstone, stalagsmall, 12, 13, 14);
        wand.AddVariations(ItemID.GraniteBlock, stalagsmall, 15, 16, 17);
        wand.AddVariations(ItemID.MarbleBlock, stalagsmall, 18, 19, 20);
        wand.AddVariations(ItemID.Hive, stalagsmall, 21, 22, 23);
        return wand;
    }
}
