using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class FountainGiant : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Fountains/FountainGiant";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 6;
            TileObjectData.newTile.Height = 7;
            TileObjectData.newTile.Origin = new Point16(2, 6);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Fountain");
            AddMapEntry(new Color(99, 99, 99), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.FountainGiant>());
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            player.cursorItemIconID = ModContent.ItemType<Items.FountainGiant>();
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY >= 128)
                CFUtils.ShiftTileY(i, j, 0, set: true, skipWire: true);
            else
                CFUtils.ShiftTileY(i, j, 128, skipWire: true);
        }

        public override bool RightClick(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY >= 128)
                CFUtils.ShiftTileY(i, j, 0, set: true);
            else
                CFUtils.ShiftTileY(i, j, 128);
            return true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 5)
            {
                frameCounter = 0;
                frame = ++frame % 4;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameY >= 128)
            {
                int frameY = tile.TileFrameY + (Main.tileFrame[Type] * 128);
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                
                spriteBatch.Draw(
                    Terraria.GameContent.TextureAssets.Tile[Type].Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tile.TileFrameX, frameY, 16, (((tile.TileFrameY % 128) == 108) ? 18 : 16)),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else return true;
        }
    }
}
