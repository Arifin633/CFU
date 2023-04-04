using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class SmallStalactites : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/SmallStalactites";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));

            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) => offsetY = -2;

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 54)
            {
                case 0:
                case 1:
                    type = DustID.Stone;
                    break;
                case 2:
                    type = DustID.Demonite;
                    break;
                case 3:
                    type = DustID.Crimstone;
                    break;
                case 4:
                    type = DustID.Sluggy;
                    break;
                case 5:
                    type = DustID.Granite;
                    break;
                case 6:
                    type = DustID.Marble;
                    break;
                case 7:
                    type = DustID.Hive;
                    break;
                case 8:
                    type = DustID.Ice_Pink;
                    break;
                case 9:
                    type = DustID.Ice_Purple;
                    break;
                case 10:
                    type = DustID.Ice_Red;
                    break;
                case 11:
                    type = DustID.Ice;
                    break;
            }
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            /* The Honey stalactite (hanging) drips honey. */
            if (((Main.tile[i, j].TileFrameX / 54) == 7) &&
                (Main.rand.Next(4) == 0) &&
                (Main.rand.Next(60) == 0))
            {
                int n = Dust.NewDust(new Vector2(i * 16 + 2, j * 16 + 6), 8, 4, DustID.Honey2);
                Main.dust[n].scale -= (float)Main.rand.Next(3) * 0.1f;
                Main.dust[n].velocity.Y = 0f;
                Main.dust[n].velocity.X *= 0.05f;
                Main.dust[n].alpha = 100;
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ItemID.StoneBlock,
                             ItemID.PearlstoneBlock,
                             ItemID.EbonstoneBlock,
                             ItemID.CrimstoneBlock,
                             ItemID.Sandstone,
                             ItemID.GraniteBlock,
                             ItemID.MarbleBlock,
                             ItemID.Hive,
                             ItemID.PinkIceBlock,
                             ItemID.PurpleIceBlock,
                             ItemID.RedIceBlock,
                             ItemID.IceBlock };
            yield return new Item(styles[(Main.tile[i, j].TileFrameX / 54)]);
        }
    }
}
