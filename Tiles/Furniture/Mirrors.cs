using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Mirrors : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Mirrors";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(133, 213, 247));
            DustType = -1;
            HitSound = SoundID.Shatter;
        }
    }
}
