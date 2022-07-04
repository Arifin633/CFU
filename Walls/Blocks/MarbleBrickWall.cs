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

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.MarbleBrickWall>();
            return true;
        }
    }
}
