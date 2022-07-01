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
    public class BiomeJars : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/BiomeJars";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(1);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addAlternate(2);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(3);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addAlternate(4);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(5);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addAlternate(6);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(7);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addAlternate(8);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
            TileObjectData.addAlternate(9);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Biome Jar");
            AddMapEntry(new Color(133, 213, 247), name);
            HitSound = SoundID.Shatter;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) =>
            (!(CFUConfig.WindEnabled()) || ((Main.tile[i, j].TileFrameX / 18) % 2 == 0));

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j].TileFrameY == 0) &&
                (Main.tile[i, j].TileFrameX / 18) % 2 != 0)
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingTile);
        }


        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameX / 36)
            {
                case 0:
                    type = (Main.rand.NextBool(2))
                        ? DustID.Glass : DustID.Grass;
                    break;
                case 1:
                    type = (Main.rand.NextBool(2))
                        ? DustID.Glass : DustID.JungleGrass;
                    break;
                case 2:
                    type = (Main.rand.NextBool(2))
                        ? DustID.Glass : DustID.CorruptPlants;
                    break;
                case 3:
                    type = (Main.rand.NextBool(2))
                        ? DustID.Glass : DustID.CrimsonPlants;
                    break;
                case 4:
                    type = (Main.rand.NextBool(2))
                        ? DustID.Glass : DustID.HallowedPlants;
                    break;
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int tileFrameX, int tileFrameY)
        {
            int[] styles = { ModContent.ItemType<Items.BiomeJarForest>(),
                             ModContent.ItemType<Items.BiomeJarJungle>(),
                             ModContent.ItemType<Items.BiomeJarCorruption>(),
                             ModContent.ItemType<Items.BiomeJarCrimson>(),
                             ModContent.ItemType<Items.BiomeJarHallow>(),};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(tileFrameX / 36)]);
        }
    }
}
