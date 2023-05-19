using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.Initializers;
using Terraria.Localization;
using Terraria.UI;
using Terraria;

namespace CFU.UI
{
    public class CFUColorSlider : UIElement
    {
        public struct HSLColor
        {
            public float Hue;
            public float Saturation;
            public float Luminance;
        }
        
        public HSLColor HSL = new HSLColor
        { Hue = 0f, Saturation = 0f, Luminance = 0f };

        public Color Color = new Color();

        Color hslToRGB(HSLColor hsl) => Main.hslToRgb(HSL.Hue,
                                                      HSL.Saturation,
                                                      HSL.Luminance);

        public ElementEvent OnColorChanged;

        void ColorChanged()
        {
            Color = hslToRGB(HSL);
            OnColorChanged(this);
        }

        private void UpdateHSL_H()
        {
            float value = UILinksInitializer.HandleSliderHorizontalInput(HSL.Hue, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
            HSL.Hue = value;
            ColorChanged();
        }

        private void UpdateHSL_S()
        {
            float value = UILinksInitializer.HandleSliderHorizontalInput(HSL.Saturation, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
            HSL.Saturation = value;
            ColorChanged();
        }

        private void UpdateHSL_L()
        {
            float value = UILinksInitializer.HandleSliderHorizontalInput(HSL.Luminance, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
            HSL.Luminance = value;
            ColorChanged();
        }

        public override void OnInitialize()
        {
            HSL = new HSLColor();
            
            var h = new UIColoredSlider(LocalizedText.Empty, () => HSL.Hue, delegate (float x)
            {
                HSL.Hue = x;
                ColorChanged();
            }, UpdateHSL_H, (float x) => Main.hslToRgb(x, 1f, 0.5f * 0.85f + 0.15f), Color.Transparent);
            h.HAlign = 1f;
            h.VAlign = 0f;
            Append(h);

            var s = new UIColoredSlider(LocalizedText.Empty, () => HSL.Saturation, delegate (float x)
            {
                HSL.Saturation = x;
                ColorChanged();
            }, UpdateHSL_S, (float x) => Main.hslToRgb(HSL.Hue, x, HSL.Luminance * 0.85f + 0.15f), Color.Transparent);
            s.HAlign = 1f;
            s.VAlign = 1/3f;
            Append(s);
            
            var l = new UIColoredSlider(LocalizedText.Empty, () => HSL.Luminance, delegate (float x)
            {
                HSL.Luminance = x;
                ColorChanged();
            }, UpdateHSL_L, (float x) => Main.hslToRgb(HSL.Hue, HSL.Saturation, x * 0.85f + 0.15f), Color.Transparent);
            l.HAlign = 1f;
            l.VAlign = 2/3f;
            Append(l);
        }
    }
}
