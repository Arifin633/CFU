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
            DustType = DustID.Marble;
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.MarbleBrickWall>();
            return true;
        }
    }
}
