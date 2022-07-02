using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class StonePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/StonePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Stone;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(128, 128, 128));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.StonePillar>());
            return true;
        }
    }
}
