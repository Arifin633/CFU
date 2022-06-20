using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Stoves : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kitchen/Stoves";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Stove");
            AddMapEntry(new Color(81, 81, 89), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Furnaces, TileID.CookingPots };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.Stove>(),
                             ModContent.ItemType<Items.OrnateStove>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, styles[(frameX / 36)]);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            if ((frameX % 36 == 0) && (frameY == 0))
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                var texture = Main.instance.TilesRenderer.GetTileDrawTexture(Main.tile[i, j], i, j);
                spriteBatch.Draw(
                    texture,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 24 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(((frameX == 0) ? 0 : 32), 36, 32, 24),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);

                Tile topTile = Main.tile[i, (j - 1)];
                /* Re-draw the tile in the top left of the stove,
                   as it gets obstructed by the stove pipe. */
                if (topTile.HasTile)
                {
                    short topTileFrameX = topTile.TileFrameX;
                    short topTileFrameY = topTile.TileFrameY;
                    /* This isn't exhaustive but should work with most cases. */
                    Main.instance.TilesRenderer.GetTileDrawData(i, j, topTile, topTile.TileType, ref topTileFrameX, ref topTileFrameY, out var topTileWidth, out var topTileHeight, out var topTileTop, out var halfBrickHeight, out var addFrX, out var addFrY, out var topTileSpriteEffects, out _, out _, out _);
                    
                    var topTileTexture = Main.instance.TilesRenderer.GetTileDrawTexture(topTile, i, j);
                    spriteBatch.Draw(
                        topTileTexture,
                        new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (16 - topTileTop) - (int)Main.screenPosition.Y) + zero,
                        new Rectangle(topTileFrameX + addFrX, topTileFrameY + addFrY, topTileWidth, topTileHeight - halfBrickHeight),
                        Lighting.GetColor(i, j), 0f, default, 1f, topTileSpriteEffects, 0f);
                }
            }
        }
    }
}
