using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class WallClocks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/WallClocks";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/WallClocksHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.Clock[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wall Clock");
            AddMapEntry(new Color(127, 92, 69), name);
            DustType = -1;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { return true; }

        static bool SwingLeft = true;
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 3)
            {
                if (frame is 6 or -6)
                {
                    frameCounter = -4;
                    SwingLeft = !SwingLeft;
                }
                else
                    frameCounter = 0;
                if (SwingLeft) frame--; else frame++;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            if (Main.tile[i, j].TileFrameY == 0 && tile.TileFrameX % 36 == 0)
            {
                // spriteBatch.Draw(
                //     ModContent.Request<Texture2D>("CFU/Textures/Tiles/Clocks/ChainBottom").Value,
                //     new Vector2(i * 16 + 11 - (int)Main.screenPosition.X, j * 16 + 32 - (int)Main.screenPosition.Y) + zero,
                //     new Rectangle(0, 0, 6, 16), Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);

                /* The drawn pendulum is rather blurry thanks to
                   the default settings of the given SpriteBatch.
                   The alternative, using a sharper raster, will
                   produce even worse results: it will appear
                   very choppy, perhaps owing to the fact the
                   pendulum is quite thin. */
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>("CFU/Textures/Tiles/Furniture/WallClocksPendulum").Value,
                    new Vector2(i * 16 + 12 + 4 - (int)Main.screenPosition.X, j * 16 + 32 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(((tile.TileFrameX / 36) * 10), 0, 10, 48),
                    Lighting.GetColor(i, j),
                    /* 0.0205 times 6 frames is 0.123, which translates to roughly 6°.  Probably. */
                    (0.0205f * Main.tileFrame[Type]),
                    new Vector2(5, 1),
                    1f, SpriteEffects.None, 0f);

                // spriteBatch.Draw(
                //     ModContent.Request<Texture2D>("CFU/Textures/Tiles/Clocks/ChainTop").Value,
                //     new Vector2(i * 16 + 17 - (int)Main.screenPosition.X, j * 16 + 32 - (int)Main.screenPosition.Y) + zero,
                //     new Rectangle(0, 0, 6, 16), Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override bool RightClick(int x, int y)
        {
            CFUtils.PrintTime();
            return true;
        }

        static readonly int[] Styles = {
            ModContent.ItemType<Items.WallClockWood>(),
            ModContent.ItemType<Items.WallClockBone>(),
            ModContent.ItemType<Items.WallClockBoreal>(),
            ModContent.ItemType<Items.WallClockCactus>(),
            ModContent.ItemType<Items.WallClockDynasty>(),
            ModContent.ItemType<Items.WallClockEbon>(),
            ModContent.ItemType<Items.WallClockFlesh>(),
            ModContent.ItemType<Items.WallClockGold>(),
            ModContent.ItemType<Items.WallClockGranite>(),
            ModContent.ItemType<Items.WallClockHoney>(),
            ModContent.ItemType<Items.WallClockIce>(),
            ModContent.ItemType<Items.WallClockLiving>(),
            ModContent.ItemType<Items.WallClockLihzard>(),
            ModContent.ItemType<Items.WallClockMarble>(),
            ModContent.ItemType<Items.WallClockMeteor>(),
            ModContent.ItemType<Items.WallClockMushroom>(),
            ModContent.ItemType<Items.WallClockObsidian>(),
            ModContent.ItemType<Items.WallClockPalm>(),
            ModContent.ItemType<Items.WallClockPearl>(),
            ModContent.ItemType<Items.WallClockPumpkin>(),
            ModContent.ItemType<Items.WallClockMahogany>(),
            ModContent.ItemType<Items.WallClockShade>(),
            ModContent.ItemType<Items.WallClockSun>(),
            ModContent.ItemType<Items.WallClockSpooky>(),
            ModContent.ItemType<Items.WallClockSteam>(),
            ModContent.ItemType<Items.WallClockPrincess>(),
            ModContent.ItemType<Items.WallClockMystic>(),
            ModContent.ItemType<Items.WallClockRoyal>(),
            ModContent.ItemType<Items.WallClockSandstone>(),
            ModContent.ItemType<Items.WallClockGlass>(),
            ModContent.ItemType<Items.WallClockSlime>(),
            ModContent.ItemType<Items.WallClockMartian>(),
            ModContent.ItemType<Items.WallClockCrystal>(),
            ModContent.ItemType<Items.WallClockSunplate>(),
            ModContent.ItemType<Items.WallClockBlue>(),
            ModContent.ItemType<Items.WallClockGreen>(),
            ModContent.ItemType<Items.WallClockPink>(),
            ModContent.ItemType<Items.WallClockSpider>(),
            ModContent.ItemType<Items.WallClockLesion>(),
            ModContent.ItemType<Items.WallClockSolar>(),
            ModContent.ItemType<Items.WallClockVortex>(),
            ModContent.ItemType<Items.WallClockNebula>(),
            ModContent.ItemType<Items.WallClockStardust>(),
            ModContent.ItemType<Items.WallClockNewSandstone>(),
            ModContent.ItemType<Items.WallClockBamboo>(),
            ModContent.ItemType<Items.WallClockCoral>(),
            ModContent.ItemType<Items.WallClockBalloon>(),
            ModContent.ItemType<Items.WallClockAsh>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameX / 36)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameX / 36)]);
        }
    }
}
