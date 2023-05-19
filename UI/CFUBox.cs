using ChadsFurnitureUpdated;

namespace CFU.UI
{
    public class CFUBox : CFUIElement
    {
        public enum BoxOrientation
        {
            Horizontal,
            Vertical
        }

        public enum BoxFitting
        {
            FitChildren,
            Fill,
            None,
        }

        public BoxOrientation Orientation = BoxOrientation.Horizontal;

        public BoxFitting HeightFit = BoxFitting.FitChildren;
        public BoxFitting WidthFit = BoxFitting.FitChildren;

        public override void Recalculate()
        {
            int height = 0;
            int width = 0;
            float inc = (Elements.Count <= 1) ? 0 : (1f / (Elements.Count - 1));
            for (int i = 0; i < Elements.Count; i++)
            {
                var dimensions = Elements[i].GetOuterDimensions();
                switch (Orientation)
                {
                    case BoxOrientation.Horizontal:
                        Elements[i].HAlign = (inc * i);
                        width += (int)dimensions.Width;
                        height = System.Math.Max((int)dimensions.Height, height);
                        break;
                    case BoxOrientation.Vertical:
                        Elements[i].VAlign = (inc * i);
                        height += (int)dimensions.Height;
                        width = System.Math.Max((int)dimensions.Width, width);
                        break;
                }
            }
            switch (HeightFit)
            {
                case BoxFitting.FitChildren:
                    CFUtils.SetHeight(this, height + (PaddingTop + PaddingBottom));
                    break;
                case BoxFitting.Fill:
                    CFUtils.SetHeight(this, (int)Parent.Height.Pixels - (PaddingTop + PaddingBottom));
                    break;
                case BoxFitting.None:
                    break;
            }
            switch (WidthFit)
            {
                case BoxFitting.FitChildren:
                    CFUtils.SetWidth(this, width + (PaddingLeft + PaddingRight));
                    break;
                case BoxFitting.Fill:
                    CFUtils.SetWidth(this, (int)Parent.Width.Pixels - (PaddingLeft + PaddingRight));
                    break;
                case BoxFitting.None:
                    break;
            }
            base.Recalculate();
        }

        public override void OnInitialize()
        {
            Recalculate();
        }
    }
}
