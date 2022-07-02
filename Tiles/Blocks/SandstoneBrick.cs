using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class SandstoneBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/SandstoneBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Sluggy;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(198, 124, 78));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.SandstoneBrick>());
            return true;
        }
    }
}
