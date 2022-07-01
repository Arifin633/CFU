using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
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
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 4;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Table");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Tables };
        }

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            Tile tile = Main.tile[i, j];
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            i -= ((frameX % 54) / 18);
            j -= (frameY != 0) ? 1 : 0;
            UpdateTables(i, j);
            return 1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail || effectOnly)
                return;

            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;
            bool royal = frameX >= 216;
            if (((frameX % 54) == 0) && (frameY == 0))
            {
                bool left = (((Main.tile[i - 3, j].TileType == Type) &&
                              ((royal && Main.tile[i - 3, j].TileFrameX >= 216) ||
                               (!royal && Main.tile[i - 3, j].TileFrameX < 216))));

                bool right = (((Main.tile[i + 3, j].TileType == Type) &&
                               ((royal && Main.tile[i + 3, j].TileFrameX >= 216) ||
                                (!royal && Main.tile[i + 3, j].TileFrameX < 216))));

                if (left)
                    UpdateTables((i - 3), j, fromRight: true, notFrom: true);
                if (right)
                    UpdateTables((i + 3), j, fromLeft: true, notFrom: true);
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.DiningTable>(),
                             ModContent.ItemType<Items.RoyalDiningTable>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, styles[(frameX / 216)]);
        }

        void UpdateTables(int i, int j, bool fromLeft = false, bool fromRight = false, bool notFrom = false)
        {
            Tile tile = Main.tile[i, j];
            int frameY = tile.TileFrameY;
            int frameX = tile.TileFrameX;
            bool royal = frameX >= 216;

            bool left = (!(notFrom && fromLeft) &&
                         (fromLeft ||
                          ((Main.tile[i - 3, j].TileType == Type) &&
                           ((royal && Main.tile[i - 3, j].TileFrameX >= 216) ||
                            (!royal && Main.tile[i - 3, j].TileFrameX < 216)))));

            bool right = (!(notFrom && fromRight) &&
                          (fromRight ||
                           ((Main.tile[i + 3, j].TileType == Type) &&
                            ((royal && Main.tile[i + 3, j].TileFrameX >= 216) ||
                             (!royal && Main.tile[i + 3, j].TileFrameX < 216)))));

            int style = (royal) ? 4 : 0;
            if (left && right)
            {
                style += 3;
            }
            else if (left)
            {
                style += 2;
            }
            else if (right)
            {
                style += 1;
            }

            if (frameX != (style * 54))
            {
                CFUtils.ShiftTileX(i, j, (short)(style * 54), set: true);
                if (left && !fromLeft)
                    UpdateTables((i - 3), j, fromRight: true);
                if (right && !fromRight)
                    UpdateTables((i + 3), j, fromLeft: true);
            }
        }
    }
}
