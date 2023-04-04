using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandstonePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandstonePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Sluggy;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(198, 124, 78));
        }
    }
}
