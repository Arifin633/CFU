using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleShortPlants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleShortPlants";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 32;
            TileObjectData.newTile.StyleMultiplier = 32;
            TileObjectData.newTile.RandomStyleRange = 12;
            TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(1);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 16;
            TileObjectData.addSubTile(2);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(3);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 6;
            TileObjectData.addSubTile(4);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(6);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(7);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(8);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(9);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(10);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 10;
            TileObjectData.addSubTile(11);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(12);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(13);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 30;
            TileObjectData.addSubTile(14);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(15);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(16);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(17);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(18);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(19);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleGrass>(),
                             ModContent.ItemType<Items.MiracleYellowFlower>(),
                             ModContent.ItemType<Items.MiracleWhiteFlower>(),
                             ModContent.ItemType<Items.MiracleRedFlower>(),
                             ModContent.ItemType<Items.MiracleBlueFlower>(),
                             ModContent.ItemType<Items.MiraclePurpleFlower>(),
                             ModContent.ItemType<Items.MiraclePinkFlower>(),
                             ModContent.ItemType<Items.MiracleCorruptGrass>(),
                             ModContent.ItemType<Items.MiracleCorruptFlower>(),
                             ModContent.ItemType<Items.MiracleJungleGrass>(),
                             ModContent.ItemType<Items.MiracleJungleFlower>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroom>(),
                             ModContent.ItemType<Items.MiracleHallowedGrass>(),
                             ModContent.ItemType<Items.MiracleHallowedFlower>(),
                             ModContent.ItemType<Items.MiracleCrimsonGrass>(),
                             ModContent.ItemType<Items.MiracleCrimsonFlower>(),
                             ModContent.ItemType<Items.MiracleMushroom>(),
                             ModContent.ItemType<Items.MiracleVileMushroom>(),
                             ModContent.ItemType<Items.MiracleJungleSpore>(),
                             ModContent.ItemType<Items.MiracleViciousMushroom>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 22)]);
            return true;
        }
    }
}
