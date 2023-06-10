using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace CFU.UI
{
    public class CFUIElement : UIElement
    {
        public delegate void ElementDrawFun(SpriteBatch spriteBatch, UIElement elt);

        public ElementDrawFun DrawFun = (spriteBatch, elt) =>
        {
            var dimensions = elt.GetOuterDimensions();
            Utils.DrawInvBG(spriteBatch,
                            new Rectangle((int)dimensions.X,
                                          (int)dimensions.Y,
                                          (int)dimensions.Width,
                                          (int)dimensions.Height),
                            new Color(23, 25, 81, 255) * 0.925f);
        };

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            DrawFun(spriteBatch, this);
        }
    }
}
