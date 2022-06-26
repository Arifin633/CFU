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
    public class Candelabras : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Candelabras";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            // Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Candelabra");
            AddMapEntry(new Color(181, 172, 190), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Torches };
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 36)
                CFUtils.ShiftTileX(i, j, 36, reset: false, skipWire: true);
            else
                CFUtils.ShiftTileX(i, j, 36, reset: true, skipWire: true);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 36)
            {
                switch (Main.tile[i, j].TileFrameY / 38)
                {
                    case 0: /* Princess */
                        r = 0.7f;
                        g = 0.9f;
                        b = 1f;
                        break;
                    case 1: /* Mystic */
                        r = 0.7f;
                        g = 0.3f;
                        b = 0.7f;
                        break;
                    case 2: /* Royal */
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
                        break;
                    case 3: /* Sandstone */
                        r = 1f;
                        g = 0.5f;
                        b = 0f;
                        break;
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 36)
            {
                CFUTileDraw.DrawFlame(i, j, spriteBatch);
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinCandelabra>(),
                             ModContent.ItemType<Items.MysticCandelabra>(),
                             ModContent.ItemType<Items.RoyalCandelabra>(),
                             ModContent.ItemType<Items.AltSandstoneCandelabra>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 38)]);
        }

    }
}
