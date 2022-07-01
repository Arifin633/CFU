using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class LargePiles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/LargePiles";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 35;
            TileObjectData.newTile.RandomStyleRange = 3;
            int[] ranges = {
                3, /* Mossy Mud */
                3, /* Hellstone Vein */
                1, /* Web & Bones */
                3, /* Web */
                1, /* Web & Body */
                3, /* Mossy Stone */
                1, /* Enchanted Sword */
                1, /* Lihzahrd Altar */
                1, /* Lihzahrd Statue */
                1, /* Lihzahrd Pile */
                2, /* Cage */
                1, /* Minecart */
                1, /* Well? */
                1, /* Dirt Pile */
                1, /* Tent */
                1, /* Wheelbarrow */
                1, /* Pole with Rope */
                3, /* Sandstone */
                3, /* Sandstone Hive */
                1, /* Granite Rock */
                5, /* Granite Ruins */
                1, /* Marble Rock */
                5, /* Marble Ruins */
                3, /* Tree */
                2, /* Leaf */
                3, /* Animal Bone */
                6, /* Bone */
                1, /* Stabbed Skeleton */
                6, /* Stone */
                1, /* Mining Helmet */
                1, /* Pickaxe */
                1, /* Sword */
                2, /* Copper Coin */
                2, /* Silver Coin */
                2, /* Gold Coin */
                3, /* Ruined Furniture */
                1, /* Ruined Chandelier */
                6, /* Snow */
                3, /* Glowing Mushroom */ };
            int acc = 3;
            foreach(int range in ranges)
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
            int style = (Main.tile[i, j].TileFrameX / 54);
            style += (35 * (Main.tile[i, j].TileFrameY / 36));
            switch (style)
            {
                case <= 2:
                    type = DustID.Stone;
                    break;
                case > 2 and <= 5:
                    type = DustID.Mud;
                    break;
                case > 5 and <= 8:
                    type = DustID.Ash;
                    break;
                case > 8 and <= 13:
                    type = DustID.Web;
                    break;
                case > 13 and <= 16:
                    type = DustID.Stone;
                    break;
                case 17:
                    type = DustID.Stone;
                    break;
                case > 17 and <= 20:
                    type = DustID.Lihzahrd;
                    break;
                case 21 or 22:
                    type = DustID.Dirt;
                    break;
                case 23:
                    type = DustID.Iron;
                    break;
                case 24:
                    type = DustID.Stone;
                    break;
                case 25:
                    type = DustID.Dirt;
                    break;
                case 26:
                    type = DustID.Bone;
                    break;
                case 27:
                    type = DustID.Iron;
                    break;
                case 28:
                    type = DustID.Dirt;
                    break;
                case > 28 and <= 34:
                    type = DustID.Sluggy;
                    break;
                case > 34 and <= 40:
                    type = DustID.Granite;
                    break;
                case > 40 and <= 46:
                    type = DustID.Marble;
                    break;
                case > 46 and <= 49:
                    type = DustID.Dirt;
                    break;
                case > 49 and <= 51:
                    type = DustID.Grass;
                    break;
                case > 51 and <= 61:
                    type = DustID.Bone;
                    break;
                case > 61 and <= 70:
                    type = DustID.Stone;
                    break;
                case 71 or 72:
                    type = DustID.Copper;
                    break;
                case 73 or 74:
                    type = DustID.Silver;
                    break;
                case 75 or 76:
                    type = DustID.Gold;
                    break;
                case > 76 and <= 79:
                    type = DustID.Dirt;
                    break;
                case 80:
                    type = DustID.Gold;
                    break;
                case > 80 and <= 86:
                    type = DustID.Ice;
                    break;
                case > 86 and <= 89:
                    type = DustID.Stone;
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
            int style = (frameX / 54);
            style += (35 * (frameY / 36));
            switch (style)
            {
                case <= 2:
                    item = ModContent.ItemType<Items.LargePileMossyJungleStone>();
                    break;
                case > 2 and <= 5:
                    item = ModContent.ItemType<Items.LargePileMossyMud>();
                    break;
                case > 5 and <= 8:
                    item = ModContent.ItemType<Items.LargePileHellstone>();
                    break;
                case 9:
                    item = ModContent.ItemType<Items.LargePileSpiderBone>();
                    break;
                case > 9 and <= 12:
                    item = ModContent.ItemType<Items.LargePileSpider>();
                    break;
                case 13:
                    item = ModContent.ItemType<Items.LargePileSpiderBody>();
                    break;
                case > 13 and <= 16:
                    item = ModContent.ItemType<Items.LargePileMossyStone>();
                    break;
                case 17:
                    item = ModContent.ItemType<Items.LargePileEnchantedSword>();
                    break;
                case 18:
                    item = ModContent.ItemType<Items.LargePileLihzahrdAltar>();
                    break;
                case 19:
                    item = ModContent.ItemType<Items.LargePileLihzahrdStatue>();
                    break;
                case 20:
                    item = ModContent.ItemType<Items.LargePileLihzahrd>();
                    break;
                case 21 or 22:
                    item = ModContent.ItemType<Items.LargePileCage>();
                    break;
                case 23:
                    item = ModContent.ItemType<Items.LargePileMinecart>();
                    break;
                case 24:
                    item = ModContent.ItemType<Items.LargePileWell>();
                    break;
                case 25:
                    item = ModContent.ItemType<Items.LargePileDirt>();
                    break;
                case 26:
                    item = ModContent.ItemType<Items.LargePileTent>();
                    break;
                case 27:
                    item = ModContent.ItemType<Items.LargePileWheelbarrow>();
                    break;
                case 28:
                    item = ModContent.ItemType<Items.LargePilePoleRope>();
                    break;
                case > 28 and <= 31:
                    item = ModContent.ItemType<Items.LargePileSandstone>();
                    break;
                case > 31 and <= 34:
                    item = ModContent.ItemType<Items.LargePileSandstoneHive>();
                    break;
                case 35:
                    item = ModContent.ItemType<Items.LargePileGraniteRock>();
                    break;
                case > 35 and <= 40:
                    item = ModContent.ItemType<Items.LargePileGraniteRuins>();
                    break;
                case 41:
                    item = ModContent.ItemType<Items.LargePileMarbleRock>();
                    break;
                case > 41 and <= 46:
                    item = ModContent.ItemType<Items.LargePileMarbleRuins>();
                    break;
                case > 46 and <= 49:
                    item = ModContent.ItemType<Items.LargePileTree>();
                    break;
                case > 49 and <= 51:
                    item = ModContent.ItemType<Items.LargePileLeaf>();
                    break;
                case > 51 and <= 54:
                    item = ModContent.ItemType<Items.LargePileBoneAnimal>();
                    break;
                case > 54 and <= 60:
                    item = ModContent.ItemType<Items.LargePileBone>();
                    break;
                case 61:
                    item = ModContent.ItemType<Items.LargePileStabbedSkeleton>();
                    break;
                case > 61 and <= 67:
                    item = ModContent.ItemType<Items.LargePileStone>();
                    break;
                case 68:
                    item = ModContent.ItemType<Items.LargePileMiningHelmet>();
                    break;
                case 69:
                    item = ModContent.ItemType<Items.LargePilePickaxe>();
                    break;
                case 70:
                    item = ModContent.ItemType<Items.LargePileSword>();
                    break;
                case 71 or 72:
                    item = ModContent.ItemType<Items.LargePileCopperCoin>();
                    break;
                case 73 or 74:
                    item = ModContent.ItemType<Items.LargePileSilverCoin>();
                    break;
                case 75 or 76:
                    item = ModContent.ItemType<Items.LargePileGoldCoin>();
                    break;
                case > 76 and <= 79:
                    item = ModContent.ItemType<Items.LargePileFurniture>();
                    break;
                case 80:
                    item = ModContent.ItemType<Items.LargePileChandelier>();
                    break;
                case > 80 and <= 86:
                    item = ModContent.ItemType<Items.LargePileSnow>();
                    break;
                case > 86 and <= 89:
                    item = ModContent.ItemType<Items.LargePileMushroom>();
                    break;
            }
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, item);
        }
    }
}
