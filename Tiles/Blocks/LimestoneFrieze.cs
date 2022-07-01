using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class LimestoneFrieze : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LimestoneSlab";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type);
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLargeFrames[Type] = 1;
            DustType = DustID.MothronEgg;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(160, 156, 146));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.LimestoneFrieze>());
            return true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => false;

        /* This tile is too wide to fit in a conventional
           non-frame-important tile texturesheet, and thus
           this abomination was born.
           FIXME: Make this into a frame-important tile,
           with placement hooks similar to those of vines. */
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tileLeft = Main.tile[i - 1, j];
            Tile tileRight = Main.tile[i + 1, j];

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Tile t = Main.tile[i, j];
            int x = 0;
            int y = 0;
            if (tileLeft.HasTile)
            {
                if (tileLeft.TileType == Type)
                {
                    if (tileRight.HasTile)
                    {
                        if (tileRight.TileType == Type)
                        {
                            x = 1;
                        }
                        else
                        {
                            x = 5;
                        }
                    }
                    else
                    {
                        x = 2;
                    }
                }
                else if (tileRight.HasTile)
                {
                    if (tileRight.TileType == Type)
                    {
                        x = 4;
                    }
                    else
                    {
                        x = 6;
                    }
                }
                else
                {
                    x = 8;
                }
            }
            else if (tileRight.HasTile)
            {
                if (tileRight.TileType == Type)
                {
                    x = 0;
                }
                else
                {
                    x = 7;
                }
            }
            else
            {
                x = 3;
            }

            if (!WorldGen.SolidTile(i - 1, j))
            {
                if (!WorldGen.SolidTile(i + 1, j))
                {
                    x = 3;
                }
                else
                {
                    x = 0;
                }
            }
            else if (!WorldGen.SolidTile(i + 1, j))
            {
                x = 2;
            }
            else
            {
                x = 1;
            }

            if (!WorldGen.SolidTile(i, j - 1))
            {
                if (!WorldGen.SolidTile(i, j + 1))
                {
                    y = 3;
                }
                else
                {
                    y = 0;
                }
            }
            else if (!WorldGen.SolidTile(i, j + 1))
            {
                y = 2;
            }
            else
            {
                y = 1;
            }

            spriteBatch.Draw(
                ModContent.Request<Texture2D>("CFU/Textures/Tiles/Blocks/LimestoneFrieze").Value,
                new Vector2(i * 16 - 6 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle((x * 28), (y * 16), 28, 16),
                Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        }
    }
}
