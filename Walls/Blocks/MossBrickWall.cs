using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class MossBrickWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/MossBrickWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = DustID.Stone;
            AddMapEntry(new Color(49, 57, 49));
        }
    }
}
