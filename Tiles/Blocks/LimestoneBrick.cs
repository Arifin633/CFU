using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class LimestoneBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LimestoneBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            DustType = DustID.MothronEgg;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(160, 156, 146));
        }
    }
}
