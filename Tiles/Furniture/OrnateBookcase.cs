using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class OrnateBookcase : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/OrnateBookcase";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.Origin = new Point16(0, 4);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Bookcases };
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
        }
    }
}
