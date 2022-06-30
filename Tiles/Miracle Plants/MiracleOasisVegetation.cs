using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleOasisVegetation : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleOasisVegetation";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 10;
            TileObjectData.newTile.StyleMultiplier = 5;
            TileObjectData.newTile.RandomStyleRange = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(1);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(3);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(5);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.RandomStyleRange = 4;
            TileObjectData.addSubTile(7);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            HitSound = SoundID.Grass;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 36)
            {
                case 0:
                    if (Main.tile[i, j].TileFrameX >= 270)
                        type = DustID.OasisCactus;
                    else
                        type = DustID.JunglePlants;
                    break;
                case 1:
                    type = DustID.HallowedPlants;
                    break;
                case 2:
                    type = DustID.CrimsonPlants;
                    break;
                case 3:
                    type = DustID.CorruptPlants;
                    break;
            }
            return true;
        }        


        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if ((!CFUConfig.WindEnabled()) ||
                (frameX >= 270))
                offsetY = 2;
        }
        
        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) =>
            (!(CFUConfig.WindEnabled()) || (Main.tile[i, j].TileFrameX >= 270));
        
        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled())&&
                (Main.tile[i, j].TileFrameX < 270) &&
                ((Main.tile[i, j].TileFrameY % 36) == 0) &&
                ((Main.tile[i, j].TileFrameX % 54) == 0))
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[,] styles = {
                { ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCactus>() },

                { ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>(),
                  ModContent.ItemType<Items.MiracleOasisHallowedCactus>() },

                { ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCrimsonCactus>() },

                { ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptVegetation>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>(),
                  ModContent.ItemType<Items.MiracleOasisCorruptCactus>() } };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 36), (frameX / 54)]);
        }
    }
}
