using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class DiningTable : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/DiningTable";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Table");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Tables };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.DiningTable>(),
                             ModContent.ItemType<Items.RoyalDiningTable>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, styles[(frameX / 108)]);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            int frameY = tile.TileFrameY;
            bool royal = tile.TileFrameX >= 108;

            i -= (((tile.TileFrameX % 108) % 54) / 18);
            bool left = ((Main.tile[i - 1, j].TileType == Type) &&
                         ((royal && Main.tile[i - 1, j].TileFrameX >= 108) ||
                          (!royal && Main.tile[i - 1, j].TileFrameX < 108)));

            bool right = ((Main.tile[i + 3, j].TileType == Type) &&
                         ((royal && Main.tile[i + 3, j].TileFrameX >= 108) ||
                          (!royal && Main.tile[i + 3, j].TileFrameX < 108)));

            bool surrounded = (left && right);

            switch (((tile.TileFrameX % 108) % 54) / 18)
            {
                case 0:
                    if (frameY == 0 && left ||
                        frameY == 18 && surrounded)
                        tile.TileFrameX = 54;
                    else
                        tile.TileFrameX = 0;
                    break;
                case 1:
                    if (frameY == 18 && surrounded)
                        tile.TileFrameX = 72;
                    else
                        tile.TileFrameX = 18;
                    break;
                case 2:
                    if (frameY == 0 && right ||
                        frameY == 18 && surrounded)
                        tile.TileFrameX = 90;
                    else
                        tile.TileFrameX = 36;
                    break;
            }

            if (royal) tile.TileFrameX += 108;

        }
    }
}
