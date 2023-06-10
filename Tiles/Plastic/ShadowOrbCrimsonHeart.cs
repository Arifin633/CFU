using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class ShadowOrbCrimsonHeart : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/ShadowOrbCrimsonHeart";

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            // TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(141, 120, 168), this.GetLocalization("MapEntry0"));
            AddMapEntry(new Color(212, 105, 105), this.GetLocalization("MapEntry1"));
            AnimationFrameHeight = 36;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 11)
            {
                frameCounter = 0;
                frame = ++frame % 2;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float rand = Main.rand.Next(-5, 6) * 0.0025f;
            if (Main.tile[i, j].TileFrameX >= 36)
            {
                r = 0.5f + rand * 2f;
                g = 0.2f + rand;
                b = 0.1f;
            }
            else
            {
                r = 0.31f + rand;
                g = 0.1f;
                b = 0.44f + rand * 2f;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.tile[i, j].TileFrameX >= 36)
            {
                type = DustID.Blood;
            }
            else
            {
                type = (Main.rand.NextBool(2)) ? DustID.Stone : DustID.Demonite;
            }
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((Main.rand.NextBool(4)) && (Main.rand.NextBool(20)))
            {
                if (Main.tile[i, j].TileFrameX >= 36)
                {
                    int n = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Blood, 0f, 0f, 100);
                    Main.dust[n].velocity.Y = 0f;
                    Main.dust[n].velocity.X *= 0.3f;
                }
                else
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Demonite, 0f, 0f, 100);
                }
            }
        }
    }
}
