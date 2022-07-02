using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleShortPlants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleShortPlants";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 32;
            TileObjectData.newTile.StyleMultiplier = 32;
            TileObjectData.newTile.RandomStyleRange = 12;
            TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(1);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 16;
            TileObjectData.addSubTile(2);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(3);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 6;
            TileObjectData.addSubTile(4);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(6);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(7);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(8);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(9);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(10);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 10;
            TileObjectData.addSubTile(11);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 12;
            TileObjectData.addSubTile(12);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 32;
            TileObjectData.addSubTile(13);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 30;
            TileObjectData.addSubTile(14);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 14;
            TileObjectData.addSubTile(15);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(16);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(17);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(18);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 1;
            TileObjectData.addSubTile(19);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(26, 196, 84));          
            AddMapEntry(new Color(122, 116, 218));
            AddMapEntry(new Color(135, 196, 26));
            AddMapEntry(new Color(182, 175, 130));
            AddMapEntry(new Color(48, 186, 135));
            AddMapEntry(new Color(203, 61, 64));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j)
        {
            switch (Main.tile[i, j].TileFrameY / 22)
            {
                case 7 or 8:
                case 17:
                    return 1;
                    break;
                case 9 or 10:
                case 18:
                    return 2;
                    break;
                case 11:
                    return 3;
                    break;
                case 12 or 13:
                    return 4;
                    break;
                case 14 or 15:
                case 19:
                    return 5;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 22)
            {
                case >= 0 and <= 6:
                case 16:
                    type = DustID.GrassBlades;
                    break;
                case 7 or 8:
                case 17:
                    type = (!Main.rand.NextBool(2))
                        ? DustID.CorruptPlants : DustID.Demonite;
                    break;
                case 9 or 10:
                case 18:
                    type = DustID.JunglePlants;
                    break;
                case 11:
                    type = DustID.Bone;
                    break;
                case 12 or 13:
                    type = DustID.HallowedPlants;
                    break;
                case 14 or 15:
                case 19:
                    type = DustID.CrimsonPlants;
                    break;
            }
            return true;
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleGrass>(),
                             ModContent.ItemType<Items.MiracleYellowFlower>(),
                             ModContent.ItemType<Items.MiracleWhiteFlower>(),
                             ModContent.ItemType<Items.MiracleRedFlower>(),
                             ModContent.ItemType<Items.MiracleBlueFlower>(),
                             ModContent.ItemType<Items.MiraclePurpleFlower>(),
                             ModContent.ItemType<Items.MiraclePinkFlower>(),
                             ModContent.ItemType<Items.MiracleCorruptGrass>(),
                             ModContent.ItemType<Items.MiracleCorruptFlower>(),
                             ModContent.ItemType<Items.MiracleJungleGrass>(),
                             ModContent.ItemType<Items.MiracleJungleFlower>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroom>(),
                             ModContent.ItemType<Items.MiracleHallowedGrass>(),
                             ModContent.ItemType<Items.MiracleHallowedFlower>(),
                             ModContent.ItemType<Items.MiracleCrimsonGrass>(),
                             ModContent.ItemType<Items.MiracleCrimsonFlower>(),
                             ModContent.ItemType<Items.MiracleMushroom>(),
                             ModContent.ItemType<Items.MiracleVileMushroom>(),
                             ModContent.ItemType<Items.MiracleJungleSpore>(),
                             ModContent.ItemType<Items.MiracleViciousMushroom>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 22)]);
            return true;
        }
    }
}
