using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Pots : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Pots";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 3;
            TileObjectData.newTile.RandomStyleRange = 12;
            for (int i = 12; i <= ((9 * 10) + 12); i += 9)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.newSubTile.RandomStyleRange = 9;
                TileObjectData.addSubTile(i);
            }
            TileObjectData.addTile(Type);
            HitSound = null;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pot");
            AddMapEntry(new Color(111, 71, 61), name);
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            int frameY = Main.tile[i, j].TileFrameY;
            frameY = (frameY <= 36) ? frameY : (frameY - 36);
            switch (frameY / 108)
            {
                case 0:
                    type = DustID.Pot;
                    break;
                case 1:
                    type = DustID.Cobalt;
                    break;
                case 2:
                    type = DustID.UnusedBrown;
                    break;
                case 3:
                    type = DustID.Bone;
                    break;
                case 4:
                    type = DustID.Ash;
                    break;
                case 5:
                case 6:
                    type = DustID.CorruptGibs;
                    break;
                case 7:
                    type = DustID.Blood;
                    break;
                case 8:
                    type = DustID.Dirt;
                    break;
                case 9:
                    type = DustID.Lihzahrd;
                    break;
                case 10:
                    type = DustID.MarblePot;
                    break;
                case 11:
                    type = DustID.DesertPot;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short x, ref short y)
        {
            offsetY = 2;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            int frameY = Main.tile[i, j].TileFrameY;
            frameY = (frameY <= 36) ? frameY : (frameY - 36);
            switch (frameY / 108)
            {
                case 5:
                case 6:
                case 7:
                    SoundEngine.PlaySound(SoundID.NPCDeath1, new Vector2(i * 16, j * 16));
                    break;
                default:
                    SoundEngine.PlaySound(SoundID.Shatter, new Vector2(i * 16, j * 16));
                    break;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.ForestPot>(),
                             ModContent.ItemType<Items.TundraPot>(),
                             ModContent.ItemType<Items.JunglePot>(),
                             ModContent.ItemType<Items.DungeonPot>(),
                             ModContent.ItemType<Items.UnderworldPot>(),
                             ModContent.ItemType<Items.CorruptionPot>(),
                             ModContent.ItemType<Items.SpiderCavePot>(),
                             ModContent.ItemType<Items.CrimsonPot>(),
                             ModContent.ItemType<Items.PyramidPot>(),
                             ModContent.ItemType<Items.LihzahrdPot>(),
                             ModContent.ItemType<Items.MarbleCavePot>(),
                             ModContent.ItemType<Items.UndergroundDesertPot>() };
            frameY = (frameY <= 36) ? frameY : (frameY - 36);
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 108)]);
        }
    }
}
