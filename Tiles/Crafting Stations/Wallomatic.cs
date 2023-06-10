using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class Wallomatic : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/Wallomatic";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(155, 128, 132));
            DustType = -1;
            AnimationFrameHeight = 54;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if ((++frameCounter >= 6 && frame != 0) || frameCounter >= 24)
            {
                frameCounter = 0;
                frame = ++frame % 12;
            }
        }
    }
}
