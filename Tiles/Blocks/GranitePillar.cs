using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class GranitePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/GranitePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            AddMapEntry(new Color(50, 46, 104));
            DustType = DustID.Granite;
            HitSound = SoundID.Tink;
        }
    }
}
