using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Tapestries : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Tapestries/Tapestries";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 3;
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addSubTile(2);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(95, 44, 7));
            DustType = -1;
        }
    }
}
