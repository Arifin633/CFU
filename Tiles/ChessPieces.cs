using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class ChessPieces : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/ChessPieces";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            for (int i = 8; i <= 13; i++)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.Style2xX);
                TileObjectData.newSubTile.Origin = new Point16(0, 2);
                TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 16, 18 };
                TileObjectData.addSubTile(i);
            }
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 2;
            TileObjectData.newSubTile.Origin = new Point16(0, 1);
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addSubTile(14);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 2;
            TileObjectData.newSubTile.Origin = new Point16(0, 1);
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addSubTile(15);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chess Piece");
            AddMapEntry(new Color(168, 178, 204), name);
            AddMapEntry(new Color(50, 46, 104), name);
        }

        public override ushort GetMapOption(int i, int j)
        {
            switch (Main.tile[i, j].TileFrameX / 36)
            {
                case 2:
                case 3:
                case 6:
                case 7:
                case 9:
                case 11:
                case 13:
                case 15:
                    return 1;
                default:
                    return 0;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 36)
            {
                case 2:
                case 3:
                case 6:
                case 7:
                case 9:
                case 11:
                case 13:
                case 15:
                    type = DustID.Granite;
                    break;
                default:
                    type = DustID.Marble;
                    break;
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.BishopWhite>(),
                             ModContent.ItemType<Items.BishopWhite>(),
                             ModContent.ItemType<Items.BishopBlack>(),
                             ModContent.ItemType<Items.BishopBlack>(),
                             ModContent.ItemType<Items.KnightWhite>(),
                             ModContent.ItemType<Items.KnightWhite>(),
                             ModContent.ItemType<Items.KnightBlack>(),
                             ModContent.ItemType<Items.KnightBlack>(),
                             ModContent.ItemType<Items.KingWhite>(),
                             ModContent.ItemType<Items.KingBlack>(),
                             ModContent.ItemType<Items.QueenWhite>(),
                             ModContent.ItemType<Items.QueenBlack>(),
                             ModContent.ItemType<Items.RookWhite>(),
                             ModContent.ItemType<Items.RookBlack>(),
                             ModContent.ItemType<Items.PawnWhite>(),
                             ModContent.ItemType<Items.PawnBlack>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 36)]);
        }
    }
}
