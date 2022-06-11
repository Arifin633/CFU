using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleJungleVegetation : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleJungleVegetation";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 12;
            TileObjectData.newTile.StyleMultiplier = 3;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.addSubTile(4);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.newSubTile.RandomStyleRange = 6;
            TileObjectData.addSubTile(6);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[,] styles = {
                { ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(), 0, 0, 0 },

                { ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>() } };
            int item = (frameY >= 36) ? styles[1, (frameX / 36)] : styles[0, (frameX / 54)];
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);
        }
    }
}
