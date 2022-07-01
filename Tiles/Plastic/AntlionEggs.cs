using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class AntlionEggs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/AntlionEggs";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(230, 215, 195));
            DustType = DustID.Sand;
            HitSound = SoundID.NPCDeath1;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 20)
                frameCounter = 0;
        }

        // public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        // {
        //     if (!CFUConfig.WindEnabled())
        //     {
        //         offsetY = 2;
        //     }
        // }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => false;

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
            else
            {
                int frameX = Main.tile[i, j].TileFrameX;
                int frameY = Main.tile[i, j].TileFrameY;
                int a = (Main.tileFrameCounter[Type] / 5);
                int b = j - frameY / 18;
                int c = i - frameX / 18;
                a += b + c;
                a %= 4;
                int addFrY = a * 36;
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture).Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 + 2 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(frameX, frameY + addFrY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.AntlionEggs>());
        }
    }
}
