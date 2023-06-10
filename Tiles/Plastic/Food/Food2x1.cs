using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Food2x1 : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Food/Food2x1";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleMultiplier = 5;
            TileObjectData.newTile.StyleWrapLimit = 5;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.addTile(Type);

            for (int i = 0; i <= 5; i++)
            {
                AddMapEntry(new Color(224, 219, 236), this.GetLocalization("MapEntry" + i));
            }
            DustType = -1;
            AnimationFrameHeight = 20;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 16)
            {
                frameCounter = 0;
                frame = ++frame % 5;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
            => offsetY = -2;
    }
}
