using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class CobWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/CobWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(150, 143, 117));
            DustType = DustID.Bone;
        }
    }
}
