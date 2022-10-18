using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.UI;
using ReLogic.Content;

namespace CFU.UI
{
    public class CFUCell : UIElement
    {
        public int CornerSize = 12;
        public int BarSize = 4;
        public bool Selected = false;
        public bool Hovered = false;
        public Asset<Texture2D> BorderTexture = ModContent.Request<Texture2D>("CFU/Textures/UI/CellBorder");
        public Asset<Texture2D> BackgroundTexture = ModContent.Request<Texture2D>("CFU/Textures/UI/CellBackground");
        public Color BorderColor = Color.Black;
        public Color HoveredBorderColor = new Color(255, 241, 69);
        public Color BackgroundColor = new Color(63, 82, 151) * 0.6f;
        public Color SelectedBackgroundColor = new Color(114, 124, 207);

        public virtual void DrawCell(SpriteBatch spriteBatch, Texture2D texture, Color color)
        {
            CalculatedStyle dimensions = base.GetDimensions();
            Point point = new Point((int)dimensions.X, (int)dimensions.Y);
            Point point2 = new Point(point.X + (int)dimensions.Width - CornerSize, point.Y + (int)dimensions.Height - CornerSize);
            int width = point2.X - point.X - CornerSize;
            int height = point2.Y - point.Y - CornerSize;
            spriteBatch.Draw(texture, new Rectangle(point.X, point.Y, CornerSize, CornerSize), new Rectangle(0, 0, CornerSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, 0, CornerSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X, point2.Y, CornerSize, CornerSize), new Rectangle(0, CornerSize + BarSize, CornerSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, CornerSize + BarSize, CornerSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + CornerSize, point.Y, width, CornerSize), new Rectangle(CornerSize, 0, BarSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + CornerSize, point2.Y, width, CornerSize), new Rectangle(CornerSize, CornerSize + BarSize, BarSize, CornerSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X, point.Y + CornerSize, CornerSize, height), new Rectangle(0, CornerSize, CornerSize, BarSize), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y + CornerSize, CornerSize, height), new Rectangle(CornerSize + BarSize, CornerSize, CornerSize, BarSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + CornerSize, point.Y + CornerSize, width, height), new Rectangle(CornerSize, CornerSize, BarSize, BarSize), color);
        }

        public override void MouseDown(UIMouseEvent evt)
        {
            foreach (CFUCell elt in Parent.Children)
            {
                elt.Selected = false;
            }
            Selected = true;
            SoundEngine.PlaySound(SoundID.MenuTick);
            base.MouseDown(evt);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            Hovered = true;
            SoundEngine.PlaySound(SoundID.MenuTick);
            base.MouseOver(evt);
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            Hovered = false;
            base.MouseOut(evt);
        }

        public override void OnDeactivate()
        {
            Hovered = false;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (BackgroundTexture != null)
            {
                DrawCell(spriteBatch, BackgroundTexture.Value, (Selected ? SelectedBackgroundColor : BackgroundColor));
            }
            if (BorderTexture != null)
            {
                DrawCell(spriteBatch, BorderTexture.Value, (Hovered ? HoveredBorderColor : BorderColor));
            }
        }
    }
}
