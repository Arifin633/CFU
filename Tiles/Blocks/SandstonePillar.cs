using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandstonePillar : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandstonePillar";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            TileID.Sets.IsBeam[Type] = true;
            DustType = DustID.Sluggy;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(198, 124, 78));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.SandstonePillar>());
            return true;
        }
    }
}
