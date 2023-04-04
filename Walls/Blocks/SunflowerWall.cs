using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class SunflowerWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/SunflowerWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(164, 96, 1));
            DustType = DustID.Sunflower;
        }
    }
}
