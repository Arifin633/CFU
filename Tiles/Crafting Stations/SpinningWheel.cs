using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    class SpinningWheel : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/SpinningWheel";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Loom };
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
            AnimationFrameHeight = 54;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 4)
            {
                frameCounter = 0;
                frame = ++frame % 2;
            }
        }
    }
}
