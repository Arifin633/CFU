using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Birdhouses : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Garden/Birdhouses";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Birdhouse");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            int counterMax = 0;
            switch (frame)
            {
                case 1 or 2 or 3 or 4:
                    counterMax = 45;
                    break;
                case >= 5 and <= 7
                  or >= 8 and <= 10:
                    counterMax = 3;
                    break;
                case >= 11 and <= 18
                  or >= 19 and <= 28:
                    counterMax = 5;
                    break;
                case >= 29 and <= 34
                  or >= 35 and <= 40:
                    counterMax = 4;
                    break;
                case >= 41 and <= 43
                  or >= 44 and <= 46:
                    counterMax = 5;
                    break;
                case >= 47 and <= 49
                  or >= 50 and <= 52:
                    counterMax = 3;
                    break;
            }

            if (++frameCounter >= counterMax)
            {
                frameCounter = 0;
                if (++frame > 52)
                    frame = 0;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.Birdhouse>(),
                             ModContent.ItemType<Items.BirdhouseCardinal>(),
                             ModContent.ItemType<Items.BirdhouseJay>(),
                             ModContent.ItemType<Items.BirdhouseRoyal>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 72)]);
        }

        enum Animation
        {
            Empty,
            StandOnPerch,
            SitOnPerch,
            StandOnRight,
            StandOnLeft,
            SitOnPerchAndBlink,
            StandOnPerchAndBlink,
            FlyDownToLeft,
            FlyUpToPerch,
            HopToRight,
            HopToLeft,
            StandOnRightAndPeck,
            StandOnLeftAndPeck,
            StandOnRightAndBlink,
            StandOnLeftAndBlink,
        }

        static void BirdAnimation(int i, int j, Animation Type)
        {
            CFUtils.ShiftTileY(i, j, (short)((int)Type * 54), set: true);
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (((tile.TileFrameY % 54) == 0) && ((tile.TileFrameX % 36) == 0))
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                int frame = Main.tileFrame[Type];
                int frameY = (tile.TileFrameY / 54);
                int frameOffset = 0;
                switch (frameY)
                {
                    case 0: /* Empty */
                        frame = 0;

                        /* Spawn bird */
                        BirdAnimation(i, j, Animation.StandOnPerch);

                        break;
                    case 1: /* Stand on perch */
                        frame = 0;

                        /* Fly down to the ground */
                        if (Main.rand.NextBool(23))
                            BirdAnimation(i, j, Animation.FlyDownToLeft);

                        /* Sit down */
                        else if (Main.rand.NextBool(13))
                            BirdAnimation(i, j, Animation.SitOnPerch);

                        /* Blink */
                        else if (Main.rand.NextBool(5))
                            BirdAnimation(i, j, Animation.StandOnPerchAndBlink);

                        /* Do nothing */

                        break;
                    case 2: /* Sit on perch*/
                        frame = 0;

                        /* Stand up */
                        if (Main.rand.NextBool(17))
                            BirdAnimation(i, j, Animation.StandOnPerch);

                        /* Blink */
                        else if (Main.rand.NextBool(5))
                            BirdAnimation(i, j, Animation.SitOnPerchAndBlink);

                        /* Do nothing */

                        break;
                    case 3: /* Stand on right */
                        frame = 0;

                        /* Hop left */
                        if (Main.rand.NextBool(17))
                            BirdAnimation(i, j, Animation.HopToLeft);

                        /* Peck */
                        else if (Main.rand.NextBool(11))
                            BirdAnimation(i, j, Animation.StandOnRightAndPeck);

                        /* Blink */
                        else if (Main.rand.NextBool(11))
                            BirdAnimation(i, j, Animation.StandOnRightAndBlink);

                        /* Do nothing */

                        break;
                    case 4: /* Stand on left*/
                        frame = 0;

                        /* Fly up to perch */
                        if (Main.rand.NextBool(29))
                            BirdAnimation(i, j, Animation.FlyUpToPerch);

                        /* Hop right */
                        else if (Main.rand.NextBool(23))
                            BirdAnimation(i, j, Animation.HopToRight);

                        /* Peck */
                        else if (Main.rand.NextBool(11))
                            BirdAnimation(i, j, Animation.StandOnLeftAndPeck);

                        /* Blink */
                        else if (Main.rand.NextBool(11))
                            BirdAnimation(i, j, Animation.StandOnLeftAndBlink);

                        /* Do nothing */

                        break;
                    case 5: /* Sit on perch and blink*/
                        frameOffset = 5;
                        if (frame < 5 || frame > 7)
                            frame = 5;

                        /* Stop blinking */
                        if (frame == 7)
                            BirdAnimation(i, j, Animation.SitOnPerch);

                        break;
                    case 6: /* Stand on perch and blink */
                        frameOffset = 8;
                        if (frame < 8 || frame > 10)
                            frame = 8;

                        /* Stop blinking */
                        if (frame == 10)
                            BirdAnimation(i, j, Animation.StandOnPerch);

                        break;
                    case 7: /* Fly down to ground */
                        frameOffset = 11;
                        if (frame < 11 || frame > 18)
                            frame = 11;

                        /* Land */
                        if (frame == 18)
                            BirdAnimation(i, j, Animation.StandOnLeft);

                        break;
                    case 8: /* Fly up to perch*/
                        frameOffset = 19;
                        if (frame < 19 || frame > 28)
                            frame = 19;

                        /* Land */
                        if (frame == 28)
                            BirdAnimation(i, j, Animation.StandOnPerch);

                        break;
                    case 9: /* Hop to right*/
                        frameOffset = 29;
                        if (frame < 29 || frame > 34)
                            frame = 29;

                        /* Stop hopping */
                        if (frame == 34)
                            BirdAnimation(i, j, Animation.StandOnRight);

                        break;
                    case 10: /* Hop to left*/
                        frameOffset = 35;
                        if (frame < 35 || frame > 40)
                            frame = 35;

                        /* Stop hopping */
                        if (frame == 40)
                            BirdAnimation(i, j, Animation.StandOnLeft);

                        break;
                    case 11: /* Peck on right */
                        frameOffset = 41;
                        if (frame < 41 || frame > 43)
                            frame = 41;

                        /* Stop pecking */
                        if (frame == 43)
                            BirdAnimation(i, j, Animation.StandOnRight);

                        break;
                    case 12: /* Peck on left*/
                        frameOffset = 44;
                        if (frame < 44 || frame > 46)
                            frame = 44;

                        /* Stop pecking */
                        if (frame == 46)
                            BirdAnimation(i, j, Animation.StandOnLeft);

                        break;
                    case 13: /* Blink on right */
                        frameOffset = 47;
                        if (frame < 47 || frame > 49)
                            frame = 47;

                        /* Stop blinking */
                        if (frame == 49)
                            BirdAnimation(i, j, Animation.StandOnRight);

                        break;
                    case 14: /* Blink on left*/
                        frameOffset = 50;
                        if (frame < 50 || frame > 52)
                            frame = 50;

                        /* Stop blinking */
                        if (frame == 52)
                            BirdAnimation(i, j, Animation.StandOnLeft);

                        break;
                }

                bool flip = ((tile.TileFrameX % 72) == 36);
                var tileEffects = (flip) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                int offsetX = (flip) ? 2 : 4;

                string texture = "";
                switch (tile.TileFrameX / 72)
                {
                    case 0:
                        texture = "BirdhouseBirdAnimation";
                        break;
                    case 1:
                        texture = "BirdhouseCardinalAnimation";
                        break;
                    case 2:
                        texture = "BirdhouseBlueJayAnimation";
                        break;
                    case 3:
                        texture = "BirdhouseGoldBirdAnimation";
                        break;
                }

                spriteBatch.Draw(
                    ModContent.Request<Texture2D>("CFU/Textures/Tiles/Garden/" + texture).Value,
                    new Vector2(i * 16 - offsetX - (int)Main.screenPosition.X, j * 16 - 8 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(((frame - frameOffset) * 40), (frameY * 60), 38, 58),
                    Lighting.GetColor(i, j), 0f, default(Vector2), 1f, tileEffects, 0f);
            }
        }
    }
}
