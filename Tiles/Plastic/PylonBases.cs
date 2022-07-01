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
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 26 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));
            TileID.Sets.DisableSmartCursor[Type] = true;
            DustType = -1;
        }

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
