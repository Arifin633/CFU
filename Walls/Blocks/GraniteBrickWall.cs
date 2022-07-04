using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class GraniteBrickWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/GraniteBrickWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(19, 18, 40));
            DustType = DustID.Granite;
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.GraniteBrickWall>();
            return true;
        }
    }
}
