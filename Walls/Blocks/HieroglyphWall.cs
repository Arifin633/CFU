using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class HieroglyphWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/HieroglyphWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(127, 43, 43));
            DustType = DustID.Sluggy;
        }
    }
}
