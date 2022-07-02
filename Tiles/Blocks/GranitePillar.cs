using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class GranitePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/GranitePillar";
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsBeam[Type] = true;
            AddMapEntry(new Color(50, 46, 104));
            DustType = DustID.Granite;
            HitSound = SoundID.Tink;
        }
        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.GranitePillar>());
            return true;
        }
    }
}
