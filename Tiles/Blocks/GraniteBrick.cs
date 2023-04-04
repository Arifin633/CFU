using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class GraniteBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/GraniteBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(50, 46, 104));
            DustType = DustID.Granite;
            HitSound = SoundID.Tink;
        }
    }
}
