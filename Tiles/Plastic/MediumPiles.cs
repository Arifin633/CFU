using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class MediumPiles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/MediumPiles";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 53;
            TileObjectData.newTile.RandomStyleRange = 6;
            int[] ranges = {
                5, /* Bone */
                5, /* Bloody Bone */
                1, /* Copper Coin */
                1, /* Silver Coin */
                1, /* Gold Coin */
                1, /* Amethyst */
                1, /* Topaz */
                1, /* Sapphire */
                1, /* Emerald */
                1, /* Ruby */
                1, /* Diamond */
                6, /* Snow */
                3, /* Ruined Furniture */
                4, /* Spider */
                3, /* Mossy Stone */
                6, /* Sandstone */
                6, /* Granite */
                6, /* Marble */
                3, /* Tree */
                3  /* Sand */ };
            int acc = 6;
            foreach (int range in ranges)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.newSubTile.RandomStyleRange = range;
                TileObjectData.addSubTile(acc);
                acc += range;
            }

            TileObjectData.addTile(Type);
            AddMapEntry(new Color(191, 142, 111));
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            int style = (Main.tile[i, j].TileFrameX / 36);
            if (Main.tile[i, j].TileFrameY != 0) style += 53;
            switch (style)
            {
                case <= 5:
                    type = DustID.Stone;
                    break;
                case > 5 and <= 15:
                    type = DustID.Bone;
                    break;
                case 16:
                    type = DustID.Copper;
                    break;
                case 17:
                    type = DustID.Silver;
                    break;
                case 18:
                    type = DustID.Gold;
                    break;
                case > 18 and <= 24:
                    type = DustID.Stone;
                    break;
                case > 24 and <= 30:
                    type = DustID.Ice;
                    break;
                case > 30 and <= 32:
                    type = DustID.Dirt;
                    break;
                case 33:
                    type = DustID.Stone;
                    break;
                case > 33 and <= 37:
                    type = DustID.Web;
                    break;
                case > 37 and <= 40:
                    type = DustID.Stone;
                    break;
                case > 40 and <= 46:
                    type = DustID.Sluggy;
                    break;
                case > 46 and <= 52:
                    type = DustID.Granite;
                    break;
                case > 52 and <= 58:
                    type = DustID.Marble;
                    break;
                case > 58 and <= 61:
                    type = DustID.Dirt;
                    break;
                case > 61 and <= 64:
                    type = DustID.Sand;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short x, ref short y)
        {
            offsetY = 2;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            int style = (frameX / 36);
            if (frameY != 0) style += 53;
            switch (style)
            {
                case <= 5:
                    item = ModContent.ItemType<Items.MediumPileStone>();
                    break;
                case > 5 and <= 10:
                    item = ModContent.ItemType<Items.MediumPileBone>();
                    break;
                case > 10 and <= 15:
                    item = ModContent.ItemType<Items.MediumPileBloodyBone>();
                    break;
                case 16:
                    item = ModContent.ItemType<Items.MediumPileCopperCoin>();
                    break;
                case 17:
                    item = ModContent.ItemType<Items.MediumPileSilverCoin>();
                    break;
                case 18:
                    item = ModContent.ItemType<Items.MediumPileGoldCoin>();
                    break;
                case 19:
                    item = ModContent.ItemType<Items.MediumPileAmethyst>();
                    break;
                case 20:
                    item = ModContent.ItemType<Items.MediumPileTopaz>();
                    break;
                case 21:
                    item = ModContent.ItemType<Items.MediumPileSapphire>();
                    break;
                case 22:
                    item = ModContent.ItemType<Items.MediumPileEmerald>();
                    break;
                case 23:
                    item = ModContent.ItemType<Items.MediumPileRuby>();
                    break;
                case 24:
                    item = ModContent.ItemType<Items.MediumPileDiamond>();
                    break;
                case > 24 and <= 30:
                    item = ModContent.ItemType<Items.MediumPileSnow>();
                    break;
                case > 30 and <= 33:
                    item = ModContent.ItemType<Items.MediumPileRuinedFurniture>();
                    break;
                case > 33 and <= 37:
                    item = ModContent.ItemType<Items.MediumPileSpider>();
                    break;
                case > 37 and <= 40:
                    item = ModContent.ItemType<Items.MediumPileMossyStone>();
                    break;
                case > 40 and <= 46:
                    item = ModContent.ItemType<Items.MediumPileSandstone>();
                    break;
                case > 46 and <= 52:
                    item = ModContent.ItemType<Items.MediumPileGranite>();
                    break;
                case > 52 and <= 58:
                    item = ModContent.ItemType<Items.MediumPileMarble>();
                    break;
                case > 58 and <= 61:
                    item = ModContent.ItemType<Items.MediumPileTree>();
                    break;
                case > 61 and <= 64:
                    item = ModContent.ItemType<Items.MediumPileSand>();
                    break;
            }
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, item);
        }
    }
}
