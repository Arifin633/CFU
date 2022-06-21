using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class MiracleVines : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleVines";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 24;
            TileObjectData.newTile.RandomStyleRange = 24;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.AnchorAlternateTiles = new int[] {  };
            // TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.addAlternate(120);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { Type };
            // TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.addAlternate(144);
            TileObjectData.addTile(Type);
            DustType = 0;
            AddMapEntry(new Color(14, 152, 64));
        }

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            Tile tileAbove = Main.tile[i, (j - 1)];
            if (tileAbove.TileType == Type)
            {
                if ((tileAbove.TileFrameY / 18) == 5)
                {
                    tileAbove.TileFrameY = (18 * 6);
                }
                if ((Main.tile[i, j].TileFrameY / 18) == 5)
                {
                    Main.tile[i, j].TileFrameY = (18 * 6);
                }
                Tile tileAboveAbove = Main.tile[i, (j - 2)];
                if (tileAboveAbove.TileType == Type)
                {
                    tileAbove.TileFrameX = (short)(18 * Main.rand.Next(48, 71));
                }
                else
                {
                    tileAbove.TileFrameX = (short)(18 * Main.rand.Next(24, 47));
                }
            }
            return 1;
        }


        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            fail = effectOnly = noItem = false;
            Tile tileAbove = Main.tile[i, (j - 1)];
            if (tileAbove.TileType == Type)
            {
                CFUTileDraw.AddSpecialPosition(i, (j - 1), CFUTileDraw.SpecialPositionType.RisingTile);
                tileAbove.TileFrameX = (short)(18 * Main.rand.Next(0, 23));
                if (((tileAbove.TileFrameY / 18) == 6) &&
                    (Main.tile[i, (j - 2)].TileType != Type))
                {
                    tileAbove.TileFrameY = (18 * 5);
                }
            }
        }


        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleVine>(),
                             ModContent.ItemType<Items.MiracleCrimsonVine>(),
                             ModContent.ItemType<Items.MiracleFlowerVine>(),
                             ModContent.ItemType<Items.MiracleHallowedVine>(),
                             ModContent.ItemType<Items.MiracleJungleVine>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroomVine>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroomVine>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[Main.tile[i, j].TileFrameY / 18]);
            return true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (Main.tile[i, j - 1].TileType != Type)
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingVine);
        }
    }
}
