using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class AntlionEggs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/AntlionEggs";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(198, 134, 88));
            DustType = DustID.Sand;
            HitSound = SoundID.NPCDeath1;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 20)
                frameCounter = 0;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) =>
            offsetY = 2;

        public override void AnimateIndividualTile (int type, int i, int j, ref int addFrX, ref int addFrY)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            int a = (Main.tileFrameCounter[Type] / 5);
            int b = j - frameY / 18;
            int c = i - frameX / 18;
            a += b + c;
            a %= 4;
            addFrY = a * 36;
        }
        
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (CFUConfig.WindEnabled())
            {
                if (((Main.tile[i, j].TileFrameX % 36) == 0) &&
                    (Main.tile[i, j].TileFrameY == 0))
                {
                    CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
                }
            }
        }
    }
}
