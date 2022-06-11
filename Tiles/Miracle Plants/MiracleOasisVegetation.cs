using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleOasisVegetation : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleOasisVegetation";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 10;
            TileObjectData.newTile.StyleMultiplier = 5;
            TileObjectData.newTile.RandomStyleRange = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(1);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(3);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(7);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[,] styles = {
                { ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>() },

                { ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>() },

                { ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>() },

                { ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>() } };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 36), (frameX / 54)]);
        }
    }
}
