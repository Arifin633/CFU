using System.IO;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    public class CFU : Mod
    {
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            if (Terraria.Main.netMode == 2)
                Tiles.MannequinHeadTE.ReceivePacket(reader);
        }
            
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

        [DefaultValue(true)]
        [ReloadRequired]
        public bool WindEnabled;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool CraftableFurniture;
    }
}
