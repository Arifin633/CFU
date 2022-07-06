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
        public static bool CraftableFurniture() => ModContent.GetInstance<Features>().CraftableFurniture;
    }

    public class Features : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Wind Swaying")]
        [Tooltip("Allows some items to be affected by the wind.\nMight detrimentally affect performance.\n\nNote that disabling the \"Windy Environment\" setting\nfrom vanilla will take precedence over this option.")]
        [DefaultValue(true)]
        [ReloadRequired]

        public bool WindEnabled;

        [Label("Craftable Vanilla Furniture")]
        [Tooltip("Makes the following vanilla furniture sets craftable:\n  Dungeon (Blue, Green, Pink, Gothic, Misc.)\n  Golden\n  Obsidian")]
        [DefaultValue(true)]
        [ReloadRequired]
        
        public bool CraftableFurniture;
    }
}
