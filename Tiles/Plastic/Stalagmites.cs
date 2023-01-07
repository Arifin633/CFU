using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Stalagmites : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Stalagmites";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));

            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) => offsetY = 2;

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
            }
            return true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ItemID.StoneBlock,
                             ItemID.PearlstoneBlock,
                             ItemID.EbonstoneBlock,
                             ItemID.CrimstoneBlock,
                             ItemID.Sandstone,
                             ItemID.GraniteBlock,
                             ItemID.MarbleBlock,
                             ItemID.Cobweb,
                             ItemID.PinkIceBlock,
                             ItemID.PurpleIceBlock,
                             ItemID.RedIceBlock,
                             ItemID.IceBlock };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 54)]);
        }
    }
}
