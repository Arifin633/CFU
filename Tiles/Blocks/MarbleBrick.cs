using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class MarbleBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/MarbleBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Marble;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(168, 178, 204));
        }
    }
}
