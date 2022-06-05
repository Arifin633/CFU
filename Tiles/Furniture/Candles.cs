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
    public class Candles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Candles";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            // Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Candle");
            AddMapEntry(new Color(181, 172, 190), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Torches };
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 18)
            {
                switch (Main.tile[i, j].TileFrameY / 18)
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

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinCandle>(),
              ModContent.ItemType<Items.MysticCandle>(),
              ModContent.ItemType<Items.RoyalCandle>(),
              ModContent.ItemType<Items.AltSandstoneCandle>() };

        public override void MouseOver(int i, int j)
        {

            Player player = Main.LocalPlayer;
            player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 18)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }


        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 18)
                Main.tile[i, j].TileFrameX = 18;
            else Main.tile[i, j].TileFrameX = 0;
        }

        public override bool RightClick(int i, int j)
        {
            HitWire(i, j);
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 18)
                CFUtils.DrawFlame(i, j, spriteBatch, "CandlesFlame");
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(Main.tile[i, j].TileFrameY / 18)]);
            return true;
        }
    }
}
