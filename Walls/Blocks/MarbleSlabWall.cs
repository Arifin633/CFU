using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class MarbleSlabWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/MarbleSlabWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = DustID.Marble;
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.MarbleSlabWall>();
            return true;
        }
    }
}
