using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class LeadGlass : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LeadGlass";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Glass;
            HitSound = SoundID.Shatter;
            AddMapEntry(new Color(133, 213, 247));
        }
    }
}
