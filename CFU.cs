using Terraria.ModLoader;

namespace ChadsFurnitureUpdated
{
    public class CFU : Mod
    {
        public override void PostSetupContent()
        {
            CFUHooks.SetupHooks();
        }
    }
}
