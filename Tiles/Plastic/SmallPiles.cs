using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class SmallPiles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/SmallPiles";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 6;

            int[] ranges = {
                6, /* Dirt */
                8, /* Bone */
                8, /* Bloody Bone */
                8, /* Broken Tool */
                6, /* Snow */
                6, /* Ice */
                6, /* Spider */
                6, /* Sandstone */
                6, /* Granite */
                6, /* Marble */
                1, /* Tree */
                4  /* Sand */};
            int acc = 6;
            foreach (int range in ranges)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.newSubTile.RandomStyleRange = range;
                TileObjectData.addSubTile(acc);
                acc += range;
            }
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(99, 99, 99));
            AddMapEntry(new Color(114, 81, 56));
            AddMapEntry(new Color(133, 133, 101));
            AddMapEntry(new Color(151, 200, 211));
            AddMapEntry(new Color(177, 183, 161));
            AddMapEntry(new Color(134, 114, 38));
            AddMapEntry(new Color(50, 46, 104));
            AddMapEntry(new Color(168, 178, 204));
            AddMapEntry(new Color(191, 142, 111));
            AddMapEntry(new Color(186, 168, 84));
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override ushort GetMapOption(int i, int j)
        {
            switch (Main.tile[i, j].TileFrameX / 18)
            {
                case <= 5:
                case > 27 and <= 35:
                    return 0;
                case > 5 and <= 11:
                    return 1;
                case > 11 and <= 27:
                    return 2;
                case > 35 and <= 47:
                    return 3;
                case > 47 and <= 53:
                    return 4;
                case > 53 and <= 59:
                    return 5;
                case > 59 and <= 65:
                    return 6;
                case > 65 and <= 71:
                    return 7;
                case 72:
                    return 8;
                case > 72 and <= 76:
                    return 9;
                default:
                    return 0;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 18)
            {
                case <= 5:
                    type = DustID.Stone;
                    break;
                case > 5 and <= 11:
                    type = DustID.Dirt;
                    break;
                case > 11 and <= 27:
                    type = DustID.Bone;
                    break;
                case > 27 and <= 35:
                    type = DustID.Dirt;
                    break;
                case > 35 and <= 47:
                    type = DustID.Ice;
                    break;
                case > 47 and <= 53:
                    type = DustID.Web;
                    break;
                case > 53 and <= 59:
                    type = DustID.Sluggy;
                    break;
                case > 59 and <= 65:
                    type = DustID.Granite;
                    break;
                case > 65 and <= 71:
                    type = DustID.Marble;
                    break;
                case 72:
                    type = DustID.Dirt;
                    break;
                case > 72 and <= 76:
                    type = DustID.Sand;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short x, ref short y)
        {
            offsetY = 2;
        }

        public override bool Drop(int i, int j)
        {
            int item = 0;
            switch (Main.tile[i, j].TileFrameX / 18)
            {
                case <= 5:
                    item = ModContent.ItemType<Items.SmallPileStone>();
                    break;
                case > 5 and <= 11:
                    item = ModContent.ItemType<Items.SmallPileDirt>();
                    break;
                case > 11 and <= 19:
                    item = ModContent.ItemType<Items.SmallPileBone>();
                    break;
                case > 19 and <= 27:
                    item = ModContent.ItemType<Items.SmallPileBloodyBone>();
                    break;
                case > 27 and <= 35:
                    item = ModContent.ItemType<Items.SmallPileBrokenTool>();
                    break;
                case > 35 and <= 41:
                    item = ModContent.ItemType<Items.SmallPileSnow>();
                    break;
                case > 41 and <= 47:
                    item = ModContent.ItemType<Items.SmallPileIce>();
                    break;
                case > 47 and <= 53:
                    item = ModContent.ItemType<Items.SmallPileSpider>();
                    break;
                case > 53 and <= 59:
                    item = ModContent.ItemType<Items.SmallPileSandstone>();
                    break;
                case > 59 and <= 65:
                    item = ModContent.ItemType<Items.SmallPileGranite>();
                    break;
                case > 65 and <= 71:
                    item = ModContent.ItemType<Items.SmallPileMarble>();
                    break;
                case 72:
                    item = ModContent.ItemType<Items.SmallPileTree>();
                    break;
                case > 72 and <= 76:
                    item = ModContent.ItemType<Items.SmallPileSand>();
                    break;
            }
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, item);
            return true;
        }
    }
}
