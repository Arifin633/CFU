using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleJungleVegetation : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleJungleVegetation";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 12;
            TileObjectData.newTile.StyleMultiplier = 3;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.newSubTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newSubTile.Width, 0);
            TileObjectData.addSubTile(4);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.newSubTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newSubTile.Width, 0);
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Width = 2;
            TileObjectData.newSubTile.RandomStyleRange = 6;
            TileObjectData.newSubTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newSubTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newSubTile.Width, 0);
            TileObjectData.addSubTile(6);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            HitSound = SoundID.Grass;
            DustType = DustID.JunglePlants;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if (!CFUConfig.WindEnabled())
            {
                int potType = ModContent.TileType<Tiles.PlantPots>();
                if ((frameY >= 36) &&
                    ((Main.tile[i, j + 1].TileType == potType) ||
                     ((Main.tile[i, j + 1].TileType == Type) &&
                      (Main.tile[i, j + 2].TileType == potType))))
                    offsetY = -4;
                else
                    offsetY = 2;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (CFUConfig.WindEnabled())
            {
                if (Main.tile[i, j].TileFrameY == 0)
                {
                    if ((Main.tile[i, j].TileFrameX % 54) == 0)
                        CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
                }
                else if (Main.tile[i, j].TileFrameY == 36)
                {
                    if ((Main.tile[i, j].TileFrameX % 36) == 0)
                        CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
                }
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[,] styles = {
                { ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleLargeFlowerBush>(), 0, 0, 0 },

                { ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleLeafBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFernBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>(),
                  ModContent.ItemType<Items.MiracleJungleFlowerBush>() } };
            int item = (frameY >= 36) ? styles[1, (frameX / 36)] : styles[0, (frameX / 54)];
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);
        }
    }
}
