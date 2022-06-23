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
    public class HangingGargoyle : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ornaments/HangingGargoyle";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;
            Main.tileWaterDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);


            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Gargoyle");
            AddMapEntry(new Color(160, 156, 146), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public static readonly int[] Styles = {
            ModContent.ItemType<Items.LimestoneHangingGargoyle>(),
            ModContent.ItemType<Items.StoneHangingGargoyle>() };

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameX / 72)]);
        }

        public override void MouseOver(int i, int j)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = Styles[(frameX / 72)];
            player.cursorItemIconText = "";
            if (frameX is >= 36 and < 72 or >= 108)
                player.cursorItemIconReversed = true;
            player.noThrow = 2;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 4)
            {
                frameCounter = 0;
                frame = ++frame % 8;
            }
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY < 36)
                CFUtils.ShiftTileY(i, j, 2, 2, 36, false, true);
            else
                CFUtils.ShiftTileY(i, j, 2, 2, 36, true, true);
        }

        public override bool RightClick(int i, int j)
        {
            HitWire(i, j);
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            int frameX = (tile.TileFrameX % 72);
            int frameY = tile.TileFrameY;
            if ((frameX is 0 or 36) &&
                ((frameY == 0) || ((frameY == 36) && Main.raining)))
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                int offsetX = (frameX == 36) ? 0 : 16;
                int x = (Main.tileFrame[Type] * 16);
                int y = (frameX == 36) ? 48 : 0;
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>("CFU/Textures/Tiles/Ornaments/HangingGargoyleWater").Value,
                    new Vector2(i * 16 + offsetX - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(x, y, 16, 48),
                    Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
