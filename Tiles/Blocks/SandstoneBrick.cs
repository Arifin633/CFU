using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandstoneBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandstoneBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Sluggy;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(198, 124, 78));
        }
    }
}
