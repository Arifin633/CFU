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
    public class MiracleSeaweed : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleSeaweed";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 14;
            // TileObjectData.newTile.StyleMultiplier = 15;
            // TileObjectData.newTile.RandomStyleRange = 15;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { Type };
            // TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.addAlternate(30);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(54, 83, 20));
            HitSound = SoundID.Grass;
            DustType = DustID.GrassBlades;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = 2;

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            /* Seaweeds have no distinction past:
               stub (no connection above or below),
               top (no connection above),
               and middle (either no connection below,
                           or connections on both ends).

               Thus, all we have to do is turn the seaweed
               below into a "middle" seaweed. */
            Tile tileBelow = Main.tile[i, (j + 1)];
            if (tileBelow.TileType == Type)
            {
                tileBelow.TileFrameY = 18;
                tileBelow.TileFrameX = (short)(18 * Main.rand.Next(0, 14));

                /* The tile below is always changed, so we always
                   update it assuming we're in multiplayer.*/
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j + 1));
            }
            return 1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail || effectOnly)
                return;

            Tile tileBelow = Main.tile[i, (j + 1)];
            if (tileBelow.TileType == Type)
            {
                /* By adding a new special point as soon as a seaweed piece
                   is destroyed we avoid the flickering that would otherwise
                   happen between the time of death and the placement of a
                   a new point in `PostDraw'. */
                if (CFUConfig.WindEnabled())
                    CFUTileDraw.AddSpecialPosition(i, (j + 1), CFUTileDraw.SpecialPositionType.RisingTile);

                /* If the tile below isn't connected to
                   another seaweed, shift it into a stub. */
                Tile tileBelowBelow = Main.tile[i, (j + 2)];
                if (tileBelowBelow.TileType != Type)
                {
                    tileBelow.TileFrameY = 0;
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(0, 1));
                }
                /* If it is, just turn it into a seaweed top. */
                else
                {
                    tileBelow.TileFrameY = 36;
                    tileBelow.TileFrameX = (short)(18 * Main.rand.Next(0, 10));
                }

                /* If we're in multiplayer update
                   the tile, since we changed it. */
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j + 1));
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j + 1].TileType != Type))
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingVine);
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ItemID.GrassSeeds);
        }
    }
}
