/* Because the `TileDrawing' class exposes very little functionality,
   this file replicates some of the mechanisms used to draw Vines,
   Lanterns, &c., including how they are affected by wind.

   This file also provides a few original functions to aid in the
   drawing of simple post draw effects and animations, such as
   `DrawFlame' and `ForgeDrawSmoke'.
   
   Tile animations which require rotation (spec. wind swaying and
   the clock pendulum swinging) should be drawn by adding the tile
   coordinates to the `SpecialPositions' array.  Then, CFUSystem's
   `PostDrawTiles', which is automatically called by tModLoader,
   will set the correct drawing filter and call the appropriate
   drawing function.  Otherwise, the texture will appear blurry.

   The actual drawing machinations of wind-affected tiles were just
   copied and slightly simplified from vanilla.  Mostly because I
   don't have the slightest clue what half of these calculations
   are really about. */

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    static class CFUTileDraw
    {
        public static WindGrid WindGrid = new WindGrid();

        public static double WindCounter;

        public static double WindCounterVine;

        public static int[] SpecialPositionsCount = new int[4] { 0, 0, 0, 0 };

        public static Point[][] SpecialPositions = new Point[4][]
        { new Point[5000], new Point[5000], new Point[5000], new Point[5000] };

        public enum SpecialPositionType
        {
            HangingTile,
            HangingVine,
            RisingVine,
            Pendulum
        }

        public static void AddSpecialPosition(int x, int y, SpecialPositionType type)
        {
            int i = (int)type;
            if (SpecialPositionsCount[i] < 5000)
                SpecialPositions[i][SpecialPositionsCount[i]++] = new Point(x, y);
        }

        public static bool TileWindData(int x, int y, int type, out float? n, out float m, out float l, out float j, out int sizeX, out int sizeY)
        {
            bool flag = false;
            n = null; m = -4f; l = 0.15f; j = 1f;
            sizeX = sizeY = 1;
            if (type == ModContent.TileType<Tiles.Chandeliers>())
            {
                n = 1f;
                m = 0f;
                sizeX = sizeY = 3;
                switch (Main.tile[x, y].TileFrameY / 54)
                {
                    case 3:
                        n = null;
                        m = -1f;
                        flag = true;
                        break;
                }
            }
            if (type == ModContent.TileType<Tiles.OrnateChandeliers>())
            {
                n = 1f;
                m = 0f;
                sizeX = sizeY = 4;
            }
            else if (type == ModContent.TileType<Tiles.Lanterns>())
            {
                n = 1f;
                m = 0f;
                sizeX = 1;
                sizeY = 2;
                switch (Main.tile[x, y].TileFrameY / 36)
                {
                    case 3:
                        n = null;
                        m = -1f;
                        flag = true;
                        break;
                }
            }
            if (type == ModContent.TileType<Tiles.BiomeJars>())
            {
                n = 1f;
                m = 0f;
                sizeX = 1;
                sizeY = 2;
            }
            else if (type == ModContent.TileType<Tiles.Banners>())
            {
                sizeX = 1;
                sizeY = 3;
            }
            else if (type == ModContent.TileType<Tiles.BannersLarge>())
            {
                sizeX = 2;
                sizeY = 3;
            }
            return flag;
        }

        public static void TileDrawData(int x, int y, Tile tile, ushort type, ref short tileFrameX, ref short tileFrameY, out int tileWidth, out int tileHeight, out int tileTop, out int addFrX, out int addFrY, out SpriteEffects tileSpriteEffects)
        {
            tileTop = 0;
            tileWidth = 16;
            tileHeight = 16;
            addFrY = Main.tileFrame[type] * 38;
            addFrX = 0;
            tileSpriteEffects = SpriteEffects.None;
            if (type == ModContent.TileType<Tiles.MiracleVine>() ||
                type == ModContent.TileType<Tiles.MiracleJungleVine>() ||
                type == ModContent.TileType<Tiles.MiracleHallowedVine>() ||
                type == ModContent.TileType<Tiles.MiracleCrimsonVine>() ||
                type == ModContent.TileType<Tiles.MiracleFlowerVine>() ||
                type == ModContent.TileType<Tiles.MiracleGlowingMushroomVine>())
            {
                tileTop = -2;
                tileSpriteEffects = (x % 2 == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            }
            // else if (type == ModContent.TileType<Tiles.BiomeJars>())
            // {
            //     tileSpriteEffects = (x % 2 == 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            // }
            // else if (type == ModContent.TileType<Tiles.Chandeliers>())
            // {
            // }
            // else if (type == ModContent.TileType<Tiles.Lanterns>())
            // {
            // }
            // else if (type == ModContent.TileType<Tiles.Banners>())
            // {
            // }
            // else if (type == ModContent.TileType<Tiles.BannersLarge>())
            // {
            // }

            /* These are more than likely unnecessary.
               Since we are only dealing with a handful of tiles, it's
               easier to just set the sprite effects and draw position
               here instead of using the designated methods that the
               functions below would usually call.
               The animation frame is also useless, as none
               of the tiles here are animated conventionally. */
            // TileLoader.SetSpriteEffects(x, y, type, ref tileSpriteEffects);
            // TileLoader.SetDrawPositions(x, y, ref tileWidth, ref tileTop, ref tileHeight, ref tileFrameX, ref tileFrameY);
            // TileLoader.SetAnimationFrame(type, x, y, ref addFrX, ref addFrY);
        }

        public static bool TileFlameData(int type, int x, int y, out string texture, out int count, out Color color, out int rangeXMin, out int rangeXMax, out int rangeYMin, out int rangeYMax, out float rangeMultX, out float rangeMultY)
        {
            count = 7;
            color = new Color(100, 100, 100, 0);
            rangeXMin = rangeYMin = -10;
            rangeXMax = 11;
            rangeYMax = 1;
            rangeMultX = 0.15f;
            rangeMultY = 0.35f;
            texture = ModContent.GetModTile(type).Texture + "Flame";
            if (type == ModContent.TileType<Tiles.Chandeliers>())
            {
                if (Main.tile[x, y].TileFrameX < 54)
                {
                    // switch (Main.tile[x, y].TileFrameY / 54) { }
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.Lanterns>())
            {
                if (Main.tile[x, y].TileFrameX < 18 &&
                    Main.tile[x, y].TileFrameY / 18 is >= 3)
                {
                    // switch (Main.tile[x, y].TileFrameY / 36) { }
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.Candles>())
            {
                if (Main.tile[x, y].TileFrameX < 18)
                {
                    // switch (Main.tile[x, y].TileFrameY / 18) { }
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.Lamps>())
            {
                if (Main.tile[x, y].TileFrameX < 18 &&
                    Main.tile[x, y].TileFrameY / 56 is 1 or 2 or 3)
                {
                    // switch (Main.tile[x, y].TileFrameY / 56) { }
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.Candelabras>())
            {
                if (Main.tile[x, y].TileFrameX < 36)
                {
                    // switch (Main.tile[x, y].TileFrameY / 38) { }
                    return true;
                }
                return true;
            }
            else if (type == ModContent.TileType<Tiles.OrnateChandeliers>())
            {
                if (Main.tile[x, y].TileFrameX < 72)
                {
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.WallCandelabras>())
            {
                if (Main.tile[x, y].TileFrameY < 36)
                {
                    return true;
                }
            }
            else if (type == ModContent.TileType<Tiles.Torches>())
            {
                if (Main.tile[x, y].TileFrameX < 66)
                {
                    return true;
                }
            }
            return false;
        }

        public static void GetScreenDrawArea(Vector2 screenPosition, Vector2 offSet, out int firstTileX, out int lastTileX, out int firstTileY, out int lastTileY)
        {
            firstTileX = (int)((screenPosition.X - offSet.X) / 16f - 1f);
            lastTileX = (int)((screenPosition.X + (float)Main.screenWidth + offSet.X) / 16f) + 2;
            firstTileY = (int)((screenPosition.Y - offSet.Y) / 16f - 1f);
            lastTileY = (int)((screenPosition.Y + (float)Main.screenHeight + offSet.Y) / 16f) + 5;
            if (firstTileX < 4)
            {
                firstTileX = 4;
            }
            if (lastTileX > Main.maxTilesX - 4)
            {
                lastTileX = Main.maxTilesX - 4;
            }
            if (firstTileY < 4)
            {
                firstTileY = 4;
            }
            if (lastTileY > Main.maxTilesY - 4)
            {
                lastTileY = Main.maxTilesY - 4;
            }
            if (Main.sectionManager.FrameSectionsLeft > 0)
            {
                TimeLogger.DetailedDrawReset();
                WorldGen.SectionTileFrameWithCheck(firstTileX, firstTileY, lastTileX, lastTileY);
                TimeLogger.DetailedDrawTime(5);
            }
        }

        public static void EnsureWindGridSize()
        {
            Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
            Vector2 offSet = (Main.drawToScreen) ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            GetScreenDrawArea(unscaledPosition, offSet, out var firstTileX, out var lastTileX, out var firstTileY, out var lastTileY);
            WindGrid.SetSize(lastTileX - firstTileX, lastTileY - firstTileY);
        }

        public static float GetWindGridPush(int i, int j, int pushAnimationTimeTotal, float pushForcePerFrame)
        {
            WindGrid.GetWindTime(i, j, pushAnimationTimeTotal, out var windTimeLeft, out var direction);
            if (windTimeLeft >= pushAnimationTimeTotal / 2)
            {
                return (float)(pushAnimationTimeTotal - windTimeLeft) * pushForcePerFrame * (float)direction;
            }
            return (float)windTimeLeft * pushForcePerFrame * (float)direction;
        }

        public static float GetWindGridPushComplex(int i, int j, int pushAnimationTimeTotal, float totalPushForce, int loops, bool flipDirectionPerLoop)
        {
            WindGrid.GetWindTime(i, j, pushAnimationTimeTotal, out var windTimeLeft, out var direction);
            float num4 = (float)windTimeLeft / (float)pushAnimationTimeTotal;
            int num2 = (int)(num4 * (float)loops);
            float num3 = num4 * (float)loops % 1f;
            if (flipDirectionPerLoop && num2 % 2 == 1)
                direction *= -1;

            if (num4 * (float)loops % 1f > 0.5f)
                return (1f - num3) * totalPushForce * (float)direction * (float)(loops - num2);

            return num3 * totalPushForce * (float)direction * (float)(loops - num2);
        }

        public static float GetHighestWindGridPushComplex(int topLeftX, int topLeftY, int sizeX, int sizeY, int totalPushTime, float pushForcePerFrame, int loops, bool swapLoopDir)
        {
            float result = 0f;
            int num = int.MaxValue;
            for (int i = 0; i < 1; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    WindGrid.GetWindTime(topLeftX + i + sizeX / 2, topLeftY + j, totalPushTime, out var windTimeLeft, out var _);
                    float windGridPushComplex = GetWindGridPushComplex(topLeftX + i, topLeftY + j, totalPushTime, pushForcePerFrame, loops, swapLoopDir);
                    if (windTimeLeft < num && windTimeLeft != 0)
                    {
                        result = windGridPushComplex;
                        num = windTimeLeft;
                    }
                }
            return result;
        }

        public static float GetWindCycle(int x, int y, double windCounter)
        {
            if (Main.SettingsEnabled_TilesSwayInWind)
            {
                float num = (float)x * 0.5f + (float)(y / 100) * 0.5f;
                float num2 = (float)Math.Cos(windCounter * 6.2831854820251465 + (double)num) * 0.5f;
                if ((double)y < Main.worldSurface)
                {
                    num2 += Main.WindForVisuals;
                    float lerpValue = Utils.GetLerpValue(0.08f, 0.18f, Math.Abs(Main.WindForVisuals), clamped: true);
                    return num2 * lerpValue;
                }
            }
            return 0f;
        }

        public static void DrawHangingTile(Point topLeft)
        {
            int topLeftX = topLeft.X;
            int topLeftY = topLeft.Y;
            Tile tile = Main.tile[topLeftX, topLeftY];
            int type = tile.TileType;
            /* The tile has been destroyed -- do nothing. */
            if (!tile.HasTile) return;

            Vector2 screenPosition = Main.Camera.UnscaledPosition;
            Vector2 offSet = Vector2.Zero;

            bool flag = TileWindData(topLeftX, topLeftY, type, out float? num3, out float num5, out float num2, out float num4, out int sizeX, out int sizeY);
            num2 *= -1f;

            float windCycle = GetHighestWindGridPushComplex(topLeftX, topLeftY, sizeX, sizeY, 60, 1.26f, 3, swapLoopDir: true);
            if (WorldGen.InAPlaceWithWind(topLeftX, topLeftY, sizeX, sizeY))
                windCycle += GetWindCycle(topLeftX, topLeftY, WindCounter);

            Vector2 value = new Vector2((float)(topLeftX * 16 - (int)screenPosition.X) + (float)sizeX * 16f * 0.5f, topLeftY * 16 - (int)screenPosition.Y) + offSet;

            Vector2 vector = new Vector2(0f, -2f);
            value += vector;

            if (flag)
                value += new Vector2(0f, 16f);

            var texture = TextureAssets.Tile[type].Value;
            for (int i = topLeftX; i < topLeftX + sizeX; i++)
                for (int j = topLeftY; j < topLeftY + sizeY; j++)
                {
                    Tile tile2 = Main.tile[i, j];
                    ushort type2 = tile2.TileType;
                    if (type2 != type)
                        continue;
                    Math.Abs(((float)(i - topLeftX) + 0.5f) / (float)sizeX - 0.5f);
                    short tileFrameX = tile2.TileFrameX;
                    short tileFrameY = tile2.TileFrameY;

                    float num7 = (float)(j - topLeftY + 1) / (float)sizeY;
                    if (flag && j == topLeftY)
                        num7 = 0f;
                    else if (num3.HasValue)
                        num7 = num3.Value;
                    else if (num7 == 0f)
                        num7 = 0.1f;

                    TileDrawData(i, j, tile, (ushort)type, ref tileFrameX, ref tileFrameY, out int tileWidth, out int tileHeight, out int tileTop, out int addFrX, out int addFrY, out SpriteEffects tileSpriteEffects);

                    Color tileLight = Lighting.GetColor(i, j);
                    Vector2 value2 = new Vector2(i * 16 - (int)screenPosition.X, j * 16 - (int)screenPosition.Y + tileTop) + offSet;
                    value2 += vector;
                    Vector2 vector2 = new Vector2(windCycle * num4, Math.Abs(windCycle) * num5 * num7);
                    Vector2 origin = value - value2;
                    Vector2 vector3 = value + new Vector2(0f, vector2.Y);
                    Rectangle value3 = new Rectangle(tileFrameX + addFrX, tileFrameY + addFrY, tileWidth, tileHeight);
                    float rotation = windCycle * num2 * num7;
                    Main.spriteBatch.Draw(texture, vector3, value3, tileLight, rotation, origin, 1f, tileSpriteEffects, 0f);

                    if (TileFlameData(type, i, j, out var flameTexture, out var flameCount, out var flameColor, out var flameRangeXMin, out var flameRangeXMax, out var flameRangeYMin, out var flameRangeYMax, out var flameRangeMultX, out var flameRangeMultY))
                    {
                        ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);
                        for (int k = 0; k < flameCount; k++)
                        {
                            float x = (float)Utils.RandomInt(ref flameSeed, flameRangeXMin, flameRangeXMax) * flameRangeMultX;
                            float y = (float)Utils.RandomInt(ref flameSeed, flameRangeYMin, flameRangeYMax) * flameRangeMultY;
                            Main.spriteBatch.Draw(ModContent.Request<Texture2D>(flameTexture).Value, vector3 + new Vector2(x, y), value3, flameColor, rotation, origin, 1f, tileSpriteEffects, 0f);
                        }

                    }
                }
        }

        public static void DrawHangingVine(Point coords)
        {
            Vector2 screenPosition = Main.Camera.UnscaledPosition;
            Vector2 offSet = Vector2.Zero;

            int x = coords.X;
            int startY = coords.Y;
            if (!Main.tile[x, startY].HasTile) return;
            ushort type = Main.tile[x, startY].TileType;

            int num = 0;
            int num2 = 0;
            Vector2 value = new Vector2(x * 16 + 8, startY * 16 - 2);
            float amount = Math.Abs(Main.WindForVisuals) / 1.2f;
            amount = MathHelper.Lerp(0.2f, 1f, amount);
            float num3 = -0.08f * amount;
            float windCycle = GetWindCycle(x, startY, WindCounterVine);
            float num4 = 0f;
            float num5 = 0f;

            var texture = TextureAssets.Tile[type].Value;
            for (int i = startY; i < Main.maxTilesY - 10; i++)
            {
                Tile tile = Main.tile[x, i];
                if (tile != null)
                {
                    if (!tile.HasTile || tile.TileType != type)
                    {
                        break;
                    }
                    num++;
                    if (num2 >= 5)
                    {
                        num3 += 0.0075f * amount;
                    }
                    if (num2 >= 2)
                    {
                        num3 += 0.0025f;
                    }
                    if (WallID.Sets.AllowsWind[tile.WallType] && (double)i < Main.worldSurface)
                    {
                        num2++;
                    }
                    float windGridPush = GetWindGridPush(x, i, 20, 0.01f);
                    num4 = ((windGridPush != 0f || num5 == 0f) ? (num4 - windGridPush) : (num4 * -0.78f));
                    num5 = windGridPush;
                    short tileFrameX = tile.TileFrameX;
                    short tileFrameY = tile.TileFrameY;
                    Color color = Lighting.GetColor(x, i);
                    TileDrawData(x, i, tile, (ushort)type, ref tileFrameX, ref tileFrameY, out int tileWidth, out int tileHeight, out int tileTop, out int addFrX, out int addFrY, out SpriteEffects tileSpriteEffects);
                    Vector2 position = new Vector2(-(int)screenPosition.X, -(int)screenPosition.Y) + offSet + value;
                    // if (tile.color() == 31) // ?
                    // {
                    //     color = Color.White;
                    // }
                    float num6 = (float)num2 * num3 * windCycle + num4;
                    Main.spriteBatch.Draw(texture, position, new Rectangle(tileFrameX + addFrX, tileFrameY + addFrY, tileWidth, tileHeight), color, num6, new Vector2(tileWidth / 2, tileTop), 1f, tileSpriteEffects, 0f);
                    value += (num6 + (float)Math.PI / 2f).ToRotationVector2() * 16f;
                }
            }
        }

        /* TODO: Merge this function with `DrawHangingVine'
           as they only differ by a couple of lines. */
        public static void DrawRisingVine(Point coords)
        {
            Vector2 screenPosition = Main.Camera.UnscaledPosition;
            Vector2 offSet = Vector2.Zero;

            int x = coords.X;
            int startY = coords.Y;
            if (!Main.tile[x, startY].HasTile) return;
            ushort type = Main.tile[x, startY].TileType;

            int num = 0;
            int num2 = 0;
            Vector2 value = new Vector2(x * 16 + 8, startY * 16 + 16 + 2);
            float amount = Math.Abs(Main.WindForVisuals) / 1.2f;
            amount = MathHelper.Lerp(0.2f, 1f, amount);
            float num3 = -0.08f * amount;
            float windCycle = GetWindCycle(x, startY, WindCounterVine);
            float num4 = 0f;
            float num5 = 0f;

            var texture = TextureAssets.Tile[type].Value;
            for (int i = startY; i > 10; i--)
            {
                Tile tile = Main.tile[x, i];
                if (tile != null)
                {
                    if (!tile.HasTile || tile.TileType != type)
                    {
                        break;
                    }
                    num++;
                    if (num2 >= 5)
                    {
                        num3 += 0.0075f * amount;
                    }
                    if (num2 >= 2)
                    {
                        num3 += 0.0025f;
                    }
                    if (WallID.Sets.AllowsWind[tile.WallType] && (double)i < Main.worldSurface)
                    {
                        num2++;
                    }
                    float windGridPush = GetWindGridPush(x, i, 40, -0.004f);
                    num4 = ((windGridPush != 0f || num5 == 0f) ? (num4 - windGridPush) : (num4 * -0.78f));
                    num5 = windGridPush;
                    short tileFrameX = tile.TileFrameX;
                    short tileFrameY = tile.TileFrameY;
                    Color color = Lighting.GetColor(x, i);
                    TileDrawData(x, i, tile, type, ref tileFrameX, ref tileFrameY, out var tileWidth, out var tileHeight, out var tileTop, out var addFrX, out var addFrY, out SpriteEffects tileSpriteEffects);
                    Vector2 position = new Vector2(-(int)screenPosition.X, -(int)screenPosition.Y) + offSet + value;
                    float num6 = (float)num2 * (0f - num3) * windCycle + num4;
                    Main.spriteBatch.Draw(texture, position, new Rectangle(tileFrameX + addFrX, tileFrameY + addFrY, tileWidth, tileHeight), color, num6, new Vector2(tileWidth / 2, tileTop + tileHeight), 1f, tileSpriteEffects, 0f);
                    value += (num6 - (float)Math.PI / 2f).ToRotationVector2() * 16f;
                }
            }
        }

        public static void DrawFlame(int i, int j, SpriteBatch spriteBatch)
        {
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            Tile tile = Main.tile[i, j];
            int type = tile.TileType;
            bool torch = (type == ModContent.TileType<Tiles.Torches>());

            int frameX = (torch) ? (tile.TileFrameX + 2) : tile.TileFrameX;
            int frameY = tile.TileFrameY;
            int offsetY = (torch && (WorldGen.SolidTile(i, j - 1))) ? 2 : 0;

            TileFlameData(type, i, j, out var flameTexture, out var flameCount, out var flameColor, out var flameRangeXMin, out var flameRangeXMax, out var flameRangeYMin, out var flameRangeYMax, out var flameRangeMultX, out var flameRangeMultY);
            ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);
            for (int k = 0; k < flameCount; k++)
            {
                float x = (float)Utils.RandomInt(ref flameSeed, flameRangeXMin, flameRangeXMax) * flameRangeMultX;
                float y = (float)Utils.RandomInt(ref flameSeed, flameRangeYMin, flameRangeYMax) * flameRangeMultY;
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(flameTexture).Value,
                    new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero,
                    new Rectangle(frameX, frameY, 16, 18),
                    flameColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }

        public static void ForgeDrawSmoke(int i, int j, SpriteBatch spriteBatch, string smoke, int smokeX, int smokeY, int Type)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            if (tile.TileFrameY % 56 == 0 && tile.TileFrameX % 72 == 0)
            {
                /* The size of the area in which tiles are considered an
                   obstruction is rather large, but that means we can safely
                   use it for all kinds of forges without change. */
                bool obstructed = false;
                for (int x = 1; x <= 3; x++)
                    for (int y = 1; y <= 2; y++)
                        if (WorldGen.SolidTile(i + x, j - y))
                            obstructed = true;

                if (!obstructed)
                    spriteBatch.Draw(
                        ModContent.Request<Texture2D>("CFU/Textures/Tiles/Stations/" + smoke).Value,
                        new Vector2(i * 16 + smokeX - (int)Main.screenPosition.X, j * 16 - smokeY - (int)Main.screenPosition.Y) + zero,
                        new Rectangle(Main.tileFrame[Type] * 32, 0, 30, 26),
                        Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}