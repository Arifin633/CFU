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
    
    public static FlexibleTileWand CreateWandCattails()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int cat = ModContent.TileType<Tiles.MiracleCattails>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, cat, 9, 0);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, cat, 9, 1);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, cat, 9, 2);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, cat, 9, 3);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, cat, 9, 4);
        wand.AddVariations_ByRow(ItemID.GlowingMushroom, cat, 9, 5);
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
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 14, 1);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 14, 2);

        /* White Flowers */
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 16, 2);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 16, 1);

        /* Red Flowers */
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 14, 3);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 14, 3);

        /* Blue Flowers */
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 6, 4);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 6, 6);

        /* Purple Flowers */
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 14, 5);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 14, 4);

        /* Pink Flowers */
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortFlowers, 12, 6);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallFlowers, 12, 5);

        /* Corruption Flowers */
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, shortFlowers, 32, 8);

        /* Jungle Flowers */
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, shortFlowers, 32, 10);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, tallFlowers, 20, 8);

        /* Hallowed Flowers */
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, shortFlowers, 32, 13);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, tallFlowers, 10, 10);

        /* Crimson Flowers */
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, shortFlowers, 14, 15);

        /* Ash Grass Flowers */
        wand.AddVariations_ByRow(ItemID.AshGrassSeeds, shortFlowers, 10, 20);

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
        wand.AddVariations_ByRow(ItemID.GrassSeeds, shortGrass, 12, 0);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, tallGrass, 12, 0);

        /* Corruption Grass */
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, shortGrass, 12, 7);

        /* Jungle Grass */
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, shortGrass, 12, 9);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, tallGrass, 12, 7);

        /* Hallowed Grass */
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, shortGrass, 12, 12);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, tallGrass, 6, 9);

        /* Crimson Grass */
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, shortGrass, 30, 14);

        /* Ash Grass */
        wand.AddVariations_ByRow(ItemID.AshGrassSeeds, shortGrass, 12, 19);

        return wand;
    }

    public static FlexibleTileWand CreateWandHerbs()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int herbs = ModContent.TileType<Tiles.MiracleHerbs>();
        wand.AddVariations_ByRow(ItemID.DaybloomSeeds, herbs, 3, 0);
        wand.AddVariations_ByRow(ItemID.MoonglowSeeds, herbs, 3, 1);
        wand.AddVariations_ByRow(ItemID.BlinkrootSeeds, herbs, 3, 2);
        wand.AddVariations_ByRow(ItemID.DeathweedSeeds, herbs, 3, 3);
        wand.AddVariations_ByRow(ItemID.WaterleafSeeds, herbs, 3, 4);
        wand.AddVariations_ByRow(ItemID.FireblossomSeeds, herbs, 3, 5);
        wand.AddVariations_ByRow(ItemID.ShiverthornSeeds, herbs, 3, 6);
        return wand;
    }

    public static FlexibleTileWand CreateWandLilyPads()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int lily = ModContent.TileType<Tiles.MiracleLilyPads>();
        wand.AddVariations_ByRow(ItemID.GrassSeeds, lily, 17, 0);
        wand.AddVariations_ByRow(ItemID.HallowedSeeds, lily, 17, 1);
        wand.AddVariations_ByRow(ItemID.JungleGrassSeeds, lily, 17, 2);
        wand.AddVariations_ByRow(ItemID.CrimsonSeeds, lily, 17, 3);
        wand.AddVariations_ByRow(ItemID.CorruptSeeds, lily, 17, 4);
        return wand;
    }

    public static FlexibleTileWand CreateWandMushrooms()
    {
        FlexibleTileWand wand = new FlexibleTileWand();
        int mushrooms = ModContent.TileType<Tiles.MiracleShortPlants>();
        wand.AddVariations_ByRow(ItemID.Mushroom, mushrooms, 1, 16);
        wand.AddVariations_ByRow(ItemID.VileMushroom, mushrooms, 1, 17);
        wand.AddVariations_ByRow(ItemID.JungleSpores, mushrooms, 1, 18);
        wand.AddVariations_ByRow(ItemID.ViciousMushroom, mushrooms, 1, 19);
        wand.AddVariations_ByRow(ItemID.GlowingMushroom, mushrooms, 10, 11);
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
        int oats = ModContent.TileType<Tiles.MiracleOasisVegetation>();
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
        wand.AddVariations(ItemID.GrassSeeds, seaweed, 0, 8);
        wand.AddVariations_ByRow(ItemID.GrassSeeds, seaweed, 15, 1, 2);
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
