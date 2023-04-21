using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    class LargeGlobe : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/LargeGlobe";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
        }
    }
}
