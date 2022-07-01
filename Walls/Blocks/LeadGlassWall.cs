using Microsoft.Xna.Framework;
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
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.LeadGlassWall>();
            return true;
        }
    }
}
