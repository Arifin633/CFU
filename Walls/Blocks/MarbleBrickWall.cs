using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class MarbleBrickWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/MarbleBrickWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(134, 141, 160));
            DustType = DustID.Marble;
        }
    }
}
