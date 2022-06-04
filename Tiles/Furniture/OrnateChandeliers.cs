using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class OrnateChandeliers : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/OrnateChandeliers";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 2, 1);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chandelier");
            AddMapEntry(new Color(224, 160, 42), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX < 70)
            {
                r = 1f;
                g = 0.95f;
                b = 0.8f;
            }
        }

        public override void HitWire(int i, int j) {
            if (Main.tile[i, j].TileFrameX < 72)
                CFUtils.ShiftTileX(i, j, 4, 4, 72, false, true);
            else
                CFUtils.ShiftTileX(i, j, 4, 4, 72, true, true);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.OrnateGoldChandelier>(),
                             ModContent.ItemType<Items.OrnatePlatinumChandelier>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 72)]);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUtils.DrawFlame(i, j, spriteBatch, "OrnateChandeliersFlame");
        }
    }
}
