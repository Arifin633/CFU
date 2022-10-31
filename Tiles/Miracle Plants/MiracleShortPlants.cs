using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleShortPlants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleShortPlants";

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 32;
            TileObjectData.newTile.StyleMultiplier = 32;
            TileObjectData.newTile.RandomStyleRange = 12;
            TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(1);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 16;
            TileObjectData.addSubTile(2);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(3);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 6;
            TileObjectData.addSubTile(4);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(6);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(7);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(8);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(9);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(10);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 10;
            TileObjectData.addSubTile(11);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(12);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(13);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 30;
            TileObjectData.addSubTile(14);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(15);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(16);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(17);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(18);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(19);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(20);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 10;
            TileObjectData.addSubTile(21);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(26, 196, 84));          
            AddMapEntry(new Color(122, 116, 218));
            AddMapEntry(new Color(135, 196, 26));
            AddMapEntry(new Color(182, 175, 130));
            AddMapEntry(new Color(48, 186, 135));
            AddMapEntry(new Color(203, 61, 64));
            AddMapEntry(new Color(100, 90, 190));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j)
        {
            switch (Main.tile[i, j].TileFrameY / 22)
            {
                case 7 or 8:
                case 17:
                    return 1;
                case 9 or 10:
                case 18:
                    return 2;
                case 11:
                    return 3;
                case 12 or 13:
                    return 4;
                case 14 or 15:
                case 19:
                    return 5;
                case 20 or 21:
                    return 6;
                default:
                    return 0;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 22)
            {
                case >= 0 and <= 6:
                case 16:
                    type = DustID.GrassBlades;
                    break;
                case 7 or 8:
                case 17:
                    type = (!Main.rand.NextBool(2))
                        ? DustID.CorruptPlants : DustID.Demonite;
                    break;
                case 9 or 10:
                case 18:
                    type = DustID.JunglePlants;
                    break;
                case 11:
                    type = DustID.Bone;
                    break;
                case 12 or 13:
                    type = DustID.HallowedPlants;
                    break;
                case 14 or 15:
                case 19:
                    type = DustID.CrimsonPlants;
                    break;
                case 20 or 21:
                    type = DustID.Mothron;
                    break;
            }
            return true;
        }

        /* We have to draw the dust in `PreDraw' because
           `PostDraw' is never called for tiles in the
           `SwaysInWindBasic' set. */
        public override bool PreDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (Main.rand.Next(4) == 0)
            {
                /* Corrupt Plants */
                int frameY = (Main.tile[i, j].TileFrameY / 22);
                if (frameY is 7 or 8 or 17 &&
                    (Main.rand.Next(500) == 0))
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Demonite);
                }

                /* Jungle Spore */
                else if (frameY is 18 &&
                         (Main.rand.Next(60) == 0))
                {
                    int n = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.JungleSpore, 0f, 0f, 250, default(Color), 0.4f);
                    Main.dust[n].fadeIn = 0.7f;
                }

                /* Glowing Mushroom */
                else if (frameY is 11 &&
                         (Main.rand.Next(500) == 0))
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.GlowingMushroom, 0f, 0f, 250, default(Color), 0.8f);
                }
            }
            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            int frameY = (Main.tile[i, j].TileFrameY / 22);
            if (frameY == 18)
            {
                float m = 1f + (float)(270 - Main.mouseTextColor) / 400f;
                float p = 0.8f - (float)(270 - Main.mouseTextColor) / 400f;
                r = 0.42f * p;
                g = 0.81f * m;
                b = 0.52f * p;
            }
            else if (frameY == 11)
            {
                float q = (float)Main.rand.Next(28, 42) * 0.005f;
                q += (float)(270 - Main.mouseTextColor) / 1000f;
                r = 0f;
                g = 0.2f + q / 2f;
                b = 1f;
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            if (frameY / 18 is 20 or 21) /* Ash Grass & Flowers */
            {
                drawData.glowTexture = ModContent.Request<Texture2D>(Texture).Value;
                drawData.glowSourceRect = new Rectangle(frameX, frameY, drawData.tileWidth, drawData.tileHeight);
                drawData.glowColor = Color.Lerp(Color.White, Lighting.GetColor(i, j), 0.75f);
            }
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = { ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.GrassSeeds,
                             ItemID.CorruptSeeds,
                             ItemID.CorruptSeeds,
                             ItemID.JungleGrassSeeds,
                             ItemID.JungleGrassSeeds,
                             ItemID.GlowingMushroom,
                             ItemID.HallowedSeeds,
                             ItemID.HallowedSeeds,
                             ItemID.CrimsonSeeds,
                             ItemID.CrimsonSeeds,
                             ItemID.Mushroom,
                             ItemID.VileMushroom,
                             ItemID.JungleSpores,
                             ItemID.ViciousMushroom/*, TODO: Uncomment in 1.4.4
                             ItemID.AshGrassSeeds
                             ItemID.AshGrassSeeds */ };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 22)]);
            return true;
        }
    }
}
