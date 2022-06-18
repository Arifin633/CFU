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
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
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
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.DiningTable>());
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            i -= ((tile.TileFrameX % 54) / 18);
            bool left = Main.tile[i - 1, j].TileType == Type;
            bool right = Main.tile[i + 3, j].TileType == Type;
            bool surrounded = (left && right);

            switch ((tile.TileFrameX % 54) / 18)
            {
                case 0:
                    if (tile.TileFrameY == 0 && left ||
                        tile.TileFrameY == 18 && surrounded)
                        tile.TileFrameX = 54;
                    else
                        tile.TileFrameX = 0;
                    break;
                case 1:
                    if (tile.TileFrameY == 18 && surrounded)
                        tile.TileFrameX = 72;
                    else
                        tile.TileFrameX = 18;
                    break;
                case 2:
                    if (tile.TileFrameY == 0 && right ||
                        tile.TileFrameY == 18 && surrounded)
                        tile.TileFrameX = 90;
                    else
                        tile.TileFrameX = 36;
                    break;
            }
        }
    }
}
