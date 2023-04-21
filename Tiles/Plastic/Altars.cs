using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Altars : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Altars";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { 26 };
            AddMapEntry(new Color(119, 101, 125), this.GetLocalization("MapEntry0"));
            AddMapEntry(new Color(214, 127, 133), this.GetLocalization("MapEntry1"));
            HitSound = null;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 54);
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float rand = Main.rand.Next(-5, 6) * 0.0025f;
            if (Main.tile[i, j].TileFrameX >= 54)
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
            if (Main.tile[i, j].TileFrameX >= 54)
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
            if ((Main.rand.Next(4) == 0) && (Main.rand.Next(20) == 0))
            {
                if (Main.tile[i, j].TileFrameX >= 54)
                {
                    int n = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Blood, 0f, 0f, 100);
                    Main.dust[n].scale = 1.5f;
                    Main.dust[n].noGravity = true;
                    Main.dust[n].velocity *= 0.75f;
                }
                else
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Demonite, 0f, 0f, 100);
                }
            }
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].TileFrameX >= 54)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath1, new Vector2(i * 16, j * 16));
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Dig, new Vector2(i * 16, j * 16));
            }
        }
    }
}
