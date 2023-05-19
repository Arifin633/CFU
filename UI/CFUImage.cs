using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace CFU.UI
{
    public class CFUImage : UIElement
    {
        public float ImageScale = 1f;
        public float Rotation;
        public bool ScaleToFit;
        public bool AllowResizingDimensions = true;
        public bool Visibility = true;
        public Color Color = Color.White;
        public Vector2 NormalizedOrigin = Vector2.Zero;
        public Vector2 Offset = Vector2.Zero;
        public Rectangle? Area = null;
        private Asset<Texture2D> _texture;
        private Texture2D _nonReloadingTexture;
        public Texture2D Texture
        {
            get
            {
                if (_nonReloadingTexture != null)
                    return _nonReloadingTexture;
                else
                    return _texture.Value;
            }
        }

        public CFUImage(Asset<Texture2D> texture)
        {
            SetImage(texture);
        }

        public CFUImage(Texture2D nonReloadingTexture)
        {
            SetImage(nonReloadingTexture);
        }

        public void SetImage(Asset<Texture2D> texture)
        {
            _texture = texture;
            _nonReloadingTexture = null;
            if (AllowResizingDimensions)
            {
                Width.Set(_texture.Value.Width, 0f);
                Height.Set(_texture.Value.Height, 0f);
            }
        }

        public void SetImage(Texture2D nonReloadingTexture)
        {
            _texture = null;
            _nonReloadingTexture = nonReloadingTexture;
            if (AllowResizingDimensions)
            {
                Width.Set(_nonReloadingTexture.Width, 0f);
                Height.Set(_nonReloadingTexture.Height, 0f);
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (Visibility)
            {
                CalculatedStyle dimensions = GetDimensions();
                if (ScaleToFit)
                {
                    spriteBatch.Draw(Texture, dimensions.ToRectangle(), Color);
                    return;
                }

                Vector2 size = new Vector2(Texture.Width, Texture.Height);
                Vector2 position = dimensions.Position() + size * (1f - ImageScale) / 2f + size * NormalizedOrigin;

                spriteBatch.Draw(Texture, position + Offset, Area, Color, Rotation, size * NormalizedOrigin, ImageScale, SpriteEffects.None, 0f);
            }
        }
    }
}
