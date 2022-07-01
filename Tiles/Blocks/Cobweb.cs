using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CFU.Tiles
{
    public class Cobweb : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Cobweb";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            DustType = DustID.GrassBlades;
            HitSound = SoundID.Grass;
            AddMapEntry(new Color(160, 156, 146));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Cobweb>());
            return true;
        }
    }
}
