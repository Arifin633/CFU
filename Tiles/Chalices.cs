using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Chalices : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Chalices";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(253, 221, 3));
            DustType = -1;
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = {
                ModContent.ItemType<Items.ChaliceGold>(),
                ModContent.ItemType<Items.ChalicePlatinum>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameX / 16)]);
            return true;
        }
    }
}
