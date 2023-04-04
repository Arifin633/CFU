using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleHerbs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleHerbs";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleWrapLimit = 3;
            // TileObjectData.newTile.StyleMultiplier = 3;
            // TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(246, 197, 26));
            AddMapEntry(new Color(76, 150, 216));
            AddMapEntry(new Color(185, 214, 42));
            AddMapEntry(new Color(167, 203, 37));
            AddMapEntry(new Color(32, 168, 117));
            AddMapEntry(new Color(177, 69, 49));
            AddMapEntry(new Color(40, 152, 240));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)((Main.tile[i, j].TileFrameX / 18) % 7);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 18)
            {
                case 0:
                case 1:
                    type = DustID.GrassBlades;
                    type = DustID.GrassBlades;
                    break;
                case 2:
                    type = DustID.WoodFurniture;
                    break;
                case 3:
                    type = DustID.CorruptPlants;
                    break;
                case 4:
                    type = DustID.SeaOatsOasis;
                    break;
                case 5:
                    type = DustID.Torch;
                    break;
                case 6:
                    type = DustID.Shiverthorn;
                    break;
            }
            return true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (Main.tile[i, j].TileFrameY == 0 && Main.rand.Next(4) == 0)
            {
                switch (Main.tile[i, j].TileFrameX / 18)
                {
                    case 0:
                        if (Main.rand.Next(100) == 0)
                        {
                            int num = Dust.NewDust(new Vector2(i * 16, j * 16 - 4), 16, 16, DustID.Sunflower, 0f, 0f, 160, default(Color), 0.1f);
                            Main.dust[num].velocity.X /= 2f;
                            Main.dust[num].velocity.Y /= 2f;
                            Main.dust[num].noGravity = true;
                            Main.dust[num].fadeIn = 1f;
                        }
                        break;
                    case 1:
                        if (Main.rand.Next(100) == 0)
                        {
                            Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.GlowingMushroom, 0f, 0f, 250, default(Color), 0.8f);
                        }
                        break;
                    case 3:
                        if (Main.rand.Next(200) == 0)
                        {
                            int num2 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Demonite, 0f, 0f, 100, default(Color), 0.2f);
                            Main.dust[num2].fadeIn = 1.2f;
                        }
                        if (Main.rand.Next(75) == 0)
                        {
                            int num3 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, 27, 0f, 0f, 100);
                            Main.dust[num3].velocity.X /= 2f;
                            Main.dust[num3].velocity.Y /= 2f;
                        }
                        break;
                    case 4:
                        if (Main.rand.Next(150) == 0)
                        {
                            int num4 = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 8, DustID.Cloud);
                            Main.dust[num4].velocity.X /= 3f;
                            Main.dust[num4].velocity.Y /= 3f;
                            Main.dust[num4].velocity.Y -= 0.7f;
                            Main.dust[num4].alpha = 50;
                            Main.dust[num4].scale *= 0.1f;
                            Main.dust[num4].fadeIn = 0.9f;
                            Main.dust[num4].noGravity = true;
                        }
                        break;
                    case 5:
                        if (Main.rand.Next(40) == 0)
                        {
                            int num5 = Dust.NewDust(new Vector2(i * 16, j * 16 - 6), 16, 16, DustID.Torch, 0f, 0f, 0, default(Color), 1.5f);
                            Main.dust[num5].velocity.Y -= 2f;
                            Main.dust[num5].noGravity = true;
                        }
                        break;
                    case 6:
                        if (Main.rand.Next(30) == 0)
                        {
                            int num6 = Dust.NewDust(newColor: new Color(50, 255, 255, 255), Position: new Vector2(i * 16, j * 16), Width: 16, Height: 16, Type: DustID.TintableDustLighted, SpeedX: 0f, SpeedY: 0f, Alpha: 254, Scale: 0.5f);
                            Main.dust[num6].velocity *= 0f;
                        }
                        break;
                }
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) => offsetY -= 2;

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = {
                ItemID.Daybloom,
                ItemID.Moonglow,
                ItemID.Blinkroot,
                ItemID.Deathweed,
                ItemID.Waterleaf,
                ItemID.Fireblossom,
                ItemID.Shiverthorn,
                ItemID.DaybloomSeeds,
                ItemID.MoonglowSeeds,
                ItemID.BlinkrootSeeds,
                ItemID.DeathweedSeeds,
                ItemID.WaterleafSeeds,
                ItemID.FireblossomSeeds,
                ItemID.ShiverthornSeeds };
            yield return new Item(styles[(Main.tile[i, j].TileFrameX / 18)]);
        }
    }
}
