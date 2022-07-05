using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleHerbs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleHerbs";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.SwaysInWindBasic[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleWrapLimit = 3;
            TileObjectData.newTile.StyleMultiplier = 3;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 20 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(246, 197, 26));
            AddMapEntry(new Color(76, 150, 216));
            AddMapEntry(new Color(185, 214, 42));
            AddMapEntry(new Color(167, 203, 37));
            AddMapEntry(new Color(32, 168, 117));
            AddMapEntry(new Color(177, 69, 49));
            AddMapEntry(new Color(40, 152, 240));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 18);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 18)
            {
                case 0:
                case 1:
                    type = DustID.GrassBlades;
                    type = DustID.GrassBlades;
                    break;
                case 2:
                    type = DustID.WoodFurniture;
                    break;
                case 3:
                    type = DustID.CorruptPlants;
                    break;
                case 4:
                    type = DustID.SeaOatsOasis;
                    break;
                case 5:
                    type = DustID.Torch;
                    break;
                case 6:
                    type = DustID.Shiverthorn;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY) => offsetY -= 2;

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleDaybloom>(),
                             ModContent.ItemType<Items.MiracleMoonglow>(),
                             ModContent.ItemType<Items.MiracleBlinkroot>(),
                             ModContent.ItemType<Items.MiracleDeathweed>(),
                             ModContent.ItemType<Items.MiracleWaterleaf>(),
                             ModContent.ItemType<Items.MiracleFireblossom>(),
                             ModContent.ItemType<Items.MiracleShiverthorn>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameX / 18)]);
            return true;
        }
    }
}
