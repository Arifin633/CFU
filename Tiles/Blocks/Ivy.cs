using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class Ivy : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Ivy";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type, mergeTo: false);
            Main.tileBlockLight[Type] = false;
            DustType = DustID.GrassBlades;
            HitSound = SoundID.Grass;
            AddMapEntry(new Color(14, 152, 64));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Ivy>());
            return true;
        }
    }
}
