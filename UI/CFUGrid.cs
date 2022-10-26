using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;

/* This file defines a basic grid framework,
   intended to be used with `CFUCells' (which see)
   or other more derived types.

   TODO: Cell span, Right-to-left orientations,
   a proper constructor to ensure no invalid types
   are appended as children nor its fields are
   modified after initialization. */

namespace CFU.UI
{
    public class CFUGrid : UIElement
    {
        public enum GridOrientation
        {
            Horizontal,
            Vertical
        }

        /* The direction cells will be laid out. */
        public GridOrientation Orientation = GridOrientation.Horizontal;

        /* The color of the grid. */
        public Color BackgroundColor = new Color(23, 25, 81, 255) * 0.925f;

        /* The maximum number of cells a row may span.
           Setting this to a negative number implies no limit.*/
        public int RowConstraints = 5;

        /* The maximum number of cells a column may span.
           Setting this to a negative number implies no limit. */
        public int ColumnConstraints = -1;

        /* The size in pixels of each cell.
           Cells are assumed to be square. */
        public int CellSize = 45;

        /* The current number of columns. */
        public int Columns
        {
            get
            {
                if (Orientation == GridOrientation.Horizontal)
                {
                    if (RowConstraints <= 0)
                        return Elements.Count;
                    else
                        return Math.Min(RowConstraints, Elements.Count);
                }
                else
                {
                    if (ColumnConstraints <= 0)
                        return 1;
                    else
                    {
                        int div = (int)Math.Ceiling((float)Elements.Count / ColumnConstraints);
                        if (RowConstraints <= 0)
                            return div;
                        else
                            return Math.Min(RowConstraints, div);
                    }
                }
            }
        }

        /* The current number of rows. */
        public int Rows
        {
            get
            {
                if (Orientation == GridOrientation.Horizontal)
                {
                    if (RowConstraints <= 0)
                        return 1;
                    else
                    {
                        int div = (int)Math.Ceiling((float)Elements.Count / RowConstraints);
                        if (ColumnConstraints <= 0)
                            return div;
                        else
                            return Math.Min(ColumnConstraints, div);
                    }
                }
                else
                {
                    if (ColumnConstraints <= 0)
                        return Elements.Count;
                    else
                        return Math.Min((ColumnConstraints), Elements.Count);
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Utils.DrawInvBG(spriteBatch,
                             new Rectangle((int)Left.Pixels, (int)Top.Pixels,
                                           (int)Width.Pixels, (int)Height.Pixels),
                             BackgroundColor);
        }

        public override void OnInitialize()
        {
            int columns = Columns;
            int rows = Rows;

            Height = StyleDimension.FromPixels((rows * CellSize) + ((((PaddingTop + PaddingBottom) / 2) - 2) * (rows - 1)) + PaddingTop + PaddingBottom);
            Width = StyleDimension.FromPixels((columns * CellSize) + ((((PaddingLeft + PaddingRight) / 2) - 2) * (columns - 1)) + PaddingLeft + PaddingRight);

            int x = 0;
            int y = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i].Height = StyleDimension.FromPixels(CellSize);
                Elements[i].Width = StyleDimension.FromPixels(CellSize);
                Elements[i].HAlign = (float)x / ((columns <= 1) ? 1 : (columns - 1));
                Elements[i].VAlign = (float)y / ((rows <= 1) ? 1 : (rows - 1));

                if (Orientation == GridOrientation.Horizontal)
                {
                    if (++x >= columns)
                    {
                        x = 0;
                        if (++y >= rows)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (++y >= rows)
                    {
                        y = 0;
                        if (++x >= columns)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public override void OnActivate()
        {
            SoundEngine.PlaySound(SoundID.MenuOpen);

            /* At this point in time, the values reported by
             mouse X and Y, as well as screen width and height,
             are inaccurate.  Both correcting the values manually
             and trying to update them through the functions in
             `PlayerInput' present issues.
             FIXME: Move these calculations to `DrawSelf',
                    where the values are already accurate. */
            float scale = (1f / Main.UIScale);
            float mouseX = Main.mouseX * scale;
            float mouseY = Main.mouseY * scale;
            float screenWidth = Main.screenWidth * scale;
            float screenHeight = Main.screenHeight * scale;

            Left.Set((mouseX - (Width.Pixels / 2)), 0);
            Top.Set((mouseY - (Height.Pixels / 2)), 0);

            if ((int)Left.Pixels + (int)Width.Pixels + 18 > screenWidth)
            {
                Left.Set((float)(screenWidth - (int)Width.Pixels - 18), 0);
            }
            if ((int)Top.Pixels + (int)Height.Pixels + 18 > screenHeight)
            {
                Top.Set((float)(screenHeight - (int)Height.Pixels - 18), 0);
            }
        }

        public override void OnDeactivate()
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
        }
    }
}
