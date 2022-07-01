using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ChadsFurnitureUpdated
{
    public class CFU : Mod
    {
        public override void PostSetupContent()
        {
            CFUHooks.SetupHooks();
        }
    }

    public static class CFUConfig
    {
        public static bool WindEnabled() => ModContent.GetInstance<Features>().WindEnabled;
    }

    public class Features : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Wind")]
        [Tooltip("Allows some items to be affected by the wind.\nMight detrimentally affect performance.\n\nNote that disabling the \"Windy Environment\" vanilla\nsetting will take precedence over this option.")]
        [DefaultValue(true)]
        [ReloadRequired]

        public bool WindEnabled;
    }
}
