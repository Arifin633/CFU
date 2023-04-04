using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class MarblePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/MarblePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Marble;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(168, 178, 204));
        }
    }
}
