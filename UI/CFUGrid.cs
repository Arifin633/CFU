using System;
using ChadsFurnitureUpdated;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;

/* This file defines a basic grid framework,
   intended to be used with evenly-sized children.

   TODO: Cell span, Right-to-left orientations */

namespace CFU.UI
{
    public class CFUGrid : CFUIElement
    {
        public enum GridOrientation
        {
            Horizontal,
            Vertical
        }

        /* The direction cells will be laid out. */
        public GridOrientation Orientation = GridOrientation.Horizontal;

        /* The maximum number of cells a row may span.
           Setting this to a negative number implies no limit.*/
        public int RowConstraints = 5;

        /* The maximum number of cells a column may span.
           Setting this to a negative number implies no limit. */
        public int ColumnConstraints = -1;

        /* The size in pixels of each cell.
           Cells are assumed to be square. */
        public int CellSize = 45;

        /* The index of the element displayed at the beginning of the grid.
           This variable is meant to be used to simulate scrolling. */
        public int Index = 0;

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

        public ElementEvent OnRecalculate;

        public override void Recalculate()
        {
            int columns = Columns;
            int rows = Rows;

            CFUtils.SetHeight(this, (rows * CellSize) + ((((PaddingTop + PaddingBottom) / 2) - 2) * (rows - 1)) + PaddingTop + PaddingBottom);
            CFUtils.SetWidth(this, (columns * CellSize) + ((((PaddingLeft + PaddingRight) / 2) - 2) * (columns - 1)) + PaddingLeft + PaddingRight);

            int x = 0;
            int y = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                if (i >= Index &&
                    ((Orientation == GridOrientation.Horizontal && y < rows) ||
                     (Orientation == GridOrientation.Vertical && x < columns)))
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
                            y += 1;
                        }
                    }
                    else
                    {
                        if (++y >= rows)
                        {
                            y = 0;
                            x += 1;
                        }
                    }
                }
                else
                {
                    Elements[i].HAlign = -100f;
                    Elements[i].VAlign = -100f;
                }
            }
            if (OnRecalculate != null)
                OnRecalculate(this);
            base.Recalculate();
        }

        public override void OnInitialize()
        {
            Recalculate();
        }

        public override void OnActivate()
        {
            SoundEngine.PlaySound(SoundID.MenuOpen);
        }

        public override void OnDeactivate()
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
        }
    }
}
