using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Paintings2xX : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Paintings/Paintings2xX";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            for (int i = 1; i <= 5; i++)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.newSubTile.Height = 3;
                TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 16, 16 };
                TileObjectData.addSubTile(i);
            }
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(95, 135, 36));
            AddMapEntry(new Color(120, 189, 108));
            AddMapEntry(new Color(75, 79, 89));
            AddMapEntry(new Color(225, 195, 52));
            AddMapEntry(new Color(1, 143, 246));
            AddMapEntry(new Color(116, 96, 96));
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);
    }
}
