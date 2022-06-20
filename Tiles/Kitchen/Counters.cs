using Terraria;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CFU.Tiles
{
    public class Counters : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kitchen/Counters";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.RandomStyleRange = 2;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.Tables };
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Counter");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.Counter>(),
                             ModContent.ItemType<Items.OrnateCounter>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, styles[(frameX / 72)]);
        }


        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            bool draw = false;
            int offsetX, x, y;
            offsetX = x = y = 0;
            int frameX = ((Main.tile[i, j].TileFrameX % 72) % 36);
            int frameY = Main.tile[i, j].TileFrameY;
            /* Left side */
            if (frameX == 0)
            {
                Tile tile = Main.tile[i - ((frameX == 0) ? 1 : 2), j];
                int type = tile.TileType;
                /* Ornate Counters */
                if (Main.tile[i, j].TileFrameX >= 72 &&
                    ((type == ModContent.TileType<OrnateFridge>()) ||
                     (type == Type && tile.TileFrameX >= 72) ||
                     (type == ModContent.TileType<Tiles.Stoves>() && tile.TileFrameX >= 36)))
                {
                    draw = true;
                    x = 106;
                    y = (frameY == 0) ? 0 : 18;
                }
                /* Regular Counters */
                else if (Main.tile[i, j].TileFrameX < 72 &&
                         ((type == ModContent.TileType<Fridge>()) ||
                          (type == Type && tile.TileFrameX < 72) ||
                          (type == ModContent.TileType<Tiles.Stoves>() && tile.TileFrameX < 36)))
                {
                    draw = true;
                    x = 34;
                    y = (frameY == 0) ? 0 : 18;
                }
            }
            /* Right side */
            else
            {
                Tile tile = Main.tile[i + ((frameX == 0) ? 2 : 1), j];
                int type = tile.TileType;
                /* Ornate Counters */
                if (Main.tile[i, j].TileFrameX >= 72 &&
                    ((type == ModContent.TileType<OrnateFridge>()) ||
                     (type == Type && tile.TileFrameX >= 72) ||
                     (type == ModContent.TileType<Tiles.Stoves>() && tile.TileFrameX >= 36)))
                {
                    draw = true;
                    offsetX = 14;
                    x = 106;
                    y = (frameY == 0) ? 0 : 18;
                }
                /* Regular Counters */
                else if (Main.tile[i, j].TileFrameX < 72 &&
                         ((type == ModContent.TileType<Fridge>()) ||
                          (type == Type && tile.TileFrameX < 72) ||
                          (type == ModContent.TileType<Tiles.Stoves>() && tile.TileFrameX < 36)))
                {
                    draw = true;
                    offsetX = 14;
                    x = 34;
                    y = (frameY == 0) ? 0 : 18;
                }
            }
            if (draw)
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                var texture = Main.instance.TilesRenderer.GetTileDrawTexture(Main.tile[i, j], i, j);
                spriteBatch.Draw(
                    texture,
                    new Vector2(i * 16 + offsetX - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(x, y, 2, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
