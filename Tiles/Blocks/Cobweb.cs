using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CFU.Tiles
{
    public class Cobweb : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Cobweb";
        public override void SetStaticDefaults()
        {
            ChadsFurnitureUpdated.CFUtils.SetupOneSidedTileMerge(Type);
            DustType = DustID.Web;
            HitSound = SoundID.Grass;
            AddMapEntry(new Color(160, 156, 146));
        }
    }
}
