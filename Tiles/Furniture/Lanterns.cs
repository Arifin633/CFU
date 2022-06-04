using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Lanterns : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Lanterns";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lamp");
            AddMapEntry(new Color(181, 172, 190), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinLantern>(),
                             ModContent.ItemType<Items.MysticLantern>(),
                             ModContent.ItemType<Items.RoyalLantern>(),
                             ModContent.ItemType<Items.AltSandstoneLantern>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 36)]);
        }


        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 18)
                CFUtils.ShiftTileX(i, j, 1, 2, 18, false, true);
            else
                CFUtils.ShiftTileX(i, j, 1, 2, 18, true, true);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 18 &&
                Main.tile[i, j].TileFrameY / 18 is >= 3 and <= 7)
            {
                CFUtils.DrawFlame(i, j, spriteBatch, "LanternsFlame");
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 18)
            {
                switch (Main.tile[i, j].TileFrameY / 18)
                {
                    case 1: /* Princess */
                        r = 0.7f;
                        g = 0.9f;
                        b = 1f;
                        break;
                    case 3: /* Mystic */
                        r = 0.7f;
                        g = 0.3f;
                        b = 0.7f;
                        break;
                    case 4: /* Royal */
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
                        break;
                    case 7: /* Sandstone */
                        r = 1f;
                        g = 0.5f;
                        b = 0f;
                        break;
                }
            }
        }
    }
}
