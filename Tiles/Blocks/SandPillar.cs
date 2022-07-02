using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandPillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandPillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Sand;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(186, 168, 84));
        }
        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.SandPillar>());
            return true;
        }
    }
}
