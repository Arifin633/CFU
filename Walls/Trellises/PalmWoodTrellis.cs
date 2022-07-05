using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class PalmWoodTrellis : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Trellises/PalmWoodTrellis";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            Main.wallLight[Type] = true;
            WallID.Sets.AllowsWind[Type] = true;
            DustType = DustID.PalmWood;
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.PalmWoodTrellis>();
            return true;
        }
    }
}
