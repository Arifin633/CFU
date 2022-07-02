using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class PylonBases : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/PylonBases";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 26 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(28, 216, 94));
            AddMapEntry(new Color(183, 237, 20));
            AddMapEntry(new Color(185, 83, 200));
            AddMapEntry(new Color(131, 128, 168));
            AddMapEntry(new Color(38, 142, 214));
            AddMapEntry(new Color(229, 154, 9));
            AddMapEntry(new Color(142, 227, 234));
            AddMapEntry(new Color(98, 111, 223));
            AddMapEntry(new Color(241, 233, 158));
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 54);

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short _x, ref short _y)
        {
            offsetY = -8;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PylonBaseForest>(),
                             ModContent.ItemType<Items.PylonBaseJungle>(),
                             ModContent.ItemType<Items.PylonBaseHallowed>(),
                             ModContent.ItemType<Items.PylonBaseUnderground>(),
                             ModContent.ItemType<Items.PylonBaseOcean>(),
                             ModContent.ItemType<Items.PylonBaseDesert>(),
                             ModContent.ItemType<Items.PylonBaseIce>(),
                             ModContent.ItemType<Items.PylonBaseMushroom>(),
                             ModContent.ItemType<Items.PylonBaseUniversal>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 54)]);
        }
    }
}
