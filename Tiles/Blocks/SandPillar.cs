using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandPillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandPillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Sand;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(186, 168, 84));
        }
    }
}
