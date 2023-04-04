using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class LeadGlassWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/LeadGlassWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            HitSound = SoundID.Shatter;
            DustType = DustID.Glass;
        }
    }
}
