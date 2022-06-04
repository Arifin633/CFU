﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ChadsFurnitureUpdated;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class FountainMarble : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Fountains/FountainMarble";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(1, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Fountain");
            AddMapEntry(new Color(168, 178, 204), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.FountainMarble>());
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = ModContent.ItemType<Items.FountainMarble>();
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY >= 74)
            { CFUtils.ShiftTileY(i, j, 2, 4, (short)74, true, true); }
            else { CFUtils.ShiftTileY(i, j, 2, 4, (short)74, false, true); }
        }

        public override bool RightClick(int i, int j)
        {
            HitWire(i, j);
            return true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 5)
            {
                frameCounter = 0;
                frame = ++frame % 6;
            }
        }

        /* TODO: Somehow de-sync the animations of different tile entities. */
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            int frameY;
            if (tile.TileFrameY < 74) { frameY = tile.TileFrameY; }
            else { frameY = tile.TileFrameY + (Main.tileFrame[Type] * 74); }

            spriteBatch.Draw(
                Terraria.GameContent.TextureAssets.Tile[Type].Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, frameY, 16, 16),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}
