using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class LimestoneSlabWall : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Blocks/LimestoneSlabWall";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(91, 80, 69));
            DustType = DustID.MothronEgg;
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.LimestoneSlabWall>();
            return true;
        }
    }
}
