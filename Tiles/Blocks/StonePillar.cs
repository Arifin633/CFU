using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class StonePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/StonePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Stone;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(128, 128, 128));
        }
    }
}
