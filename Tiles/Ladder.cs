using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Ladder : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ladder";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Ladder");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.Ladder>());
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            // Top of the ladder.
            if (Main.tile[i, j - 1].TileType != Type)
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture).Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tile.TileFrameX, tile.TileFrameY + 90, 16, 16),
                    Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
