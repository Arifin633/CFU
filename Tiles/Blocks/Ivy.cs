using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class Ivy : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Ivy";
        public override void SetStaticDefaults()
        {
            ChadsFurnitureUpdated.CFUtils.SetupOneSidedTileMerge(Type);
            DustType = DustID.GrassBlades;
            HitSound = SoundID.Grass;
            AddMapEntry(new Color(14, 152, 64));
        }
    }
}
