using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using System.Collections.Generic;
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
            TileID.Sets.DisableSmartCursor[Type] = true;
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
            AddMapEntry(new Color(28, 216, 94));
            AddMapEntry(new Color(143, 215, 29));
            AddMapEntry(new Color(141, 137, 223));
            AddMapEntry(new Color(208, 80, 80));
            AddMapEntry(new Color(78, 193, 227));
            HitSound = SoundID.Shatter;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

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

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.BiomeJarForest>(),
                             ModContent.ItemType<Items.BiomeJarJungle>(),
                             ModContent.ItemType<Items.BiomeJarCorruption>(),
                             ModContent.ItemType<Items.BiomeJarCrimson>(),
                             ModContent.ItemType<Items.BiomeJarHallow>() };
            yield return new Item(styles[(Main.tile[i, j].TileFrameX / 36)]);
        }
    }
}
