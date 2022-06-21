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
    public class MiracleCattails : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleCattails";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 9;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.WaterPlacement = LiquidPlacement.OnlyInLiquid;
            TileObjectData.addAlternate(3);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.addAlternate(6);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(25, 193, 97));
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            /* Glossary:
              
               0  <- Flower | Underwater Flower ->  o
               |  <- Stem                           |
              \|/ <- Base                          \|/

            */

            /* Only proceed if we're not placing a base
               as those don't need any special handling */
            if (alternate != 0)
            {
                Tile tileBelow = Main.tile[i, (j + 1)];
                Tile tile = Main.tile[i, j];

                /* If we're above a non-connecting base,
                   shift it to the connecting version. */
                if ((tileBelow.TileFrameX / 18) is 0 or 1 or 2)
                {
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(9, 11));
                }
                else
                {
                    switch (tile.TileFrameX / 18)
                    {
                        /* Each of the three surface flower variations
                           have a special corresponding stem.  If we
                           are placing one, shift the stem below to
                           correct version... */
                        case 6:
                            tileBelow.TileFrameX = (18 * 13);
                            break;
                        case 7:
                            tileBelow.TileFrameX = (18 * 14);
                            break;
                        case 8:
                            tileBelow.TileFrameX = (18 * 15);
                            break;
                        /* ...and if we're not, use the regular stem. */
                        default:
                            tileBelow.TileFrameX = (18 * 12);
                            break;
                    }

                    /* If the tile below the one we just currently turned into
                       a stem happens to be one of the special stems mentioned
                       above, turn it into a regular stem. */
                    Tile tileBelowBelow = Main.tile[i, (j + 2)];
                    if (tileBelowBelow.TileType == Type &&
                        (tileBelowBelow.TileFrameX / 18) is 13 or 14 or 15)
                    {
                        tileBelowBelow.TileFrameX = (18 * 12);
                    }

                }
            }
            return 1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            fail = effectOnly = noItem = false;
            Tile tileBelow = Main.tile[i, (j + 1)];
            if (tileBelow.TileType == Type)
            {
                /* By adding a new special point as soon as a cattail piece
                   is destroyed we avoid the flickering that would otherwise
                   happen between the time of death and the placement of a
                   a new point in `PostDraw'. */
                CFUTileDraw.AddSpecialPosition(i, (j + 1), CFUTileDraw.SpecialPositionType.RisingTile);

                /* If we're above a connecting base, turn it
                   into a stubby non-connecting base. */
                if ((tileBelow.TileFrameX / 18) is 9 or 10 or 11)
                {
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(0, 2));
                }
                else
                {
                    /* If we're underwater, turn the tile
                       below into an underwater flower,... */
                    if (tileBelow.LiquidAmount > 0)
                    {
                        tileBelow.TileFrameX = (18 * 3);
                    }
                    else
                    {
                        /* ...otherwise, use one of the surface flowers... */
                        int frameX = (18 * Main.rand.Next(6, 8));
                        tileBelow.TileFrameX = (short)frameX;

                        /* ...and, if the surface flower we just placed
                           has a stem below it, turn it into the correct
                           special stem variation. */
                        Tile tileBelowBelow = Main.tile[i, (j + 2)];
                        if (tileBelowBelow.TileType == Type &&
                            (tileBelowBelow.TileFrameX / 18) is 12)
                        {
                            switch (frameX / 18)
                            {
                                case 6:
                                    tileBelowBelow.TileFrameX = (18 * 13);
                                    break;
                                case 7:
                                    tileBelowBelow.TileFrameX = (18 * 14);
                                    break;
                                case 8:
                                    tileBelowBelow.TileFrameX = (18 * 15);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (Main.tile[i, j - 1].TileType != Type)
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleCattail>(),
                             ModContent.ItemType<Items.MiracleJungleCattail>(),
                             ModContent.ItemType<Items.MiracleHallowedCattail>(),
                             ModContent.ItemType<Items.MiracleCrimsonCattail>(),
                             ModContent.ItemType<Items.MiracleCorruptCattail>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroomCattail>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 18)]);
            return true;
        }
    }
}
