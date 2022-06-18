using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class Shingles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Shingles";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type, mergeTo: false);
            Main.tileBlockLight[Type] = true;
            DustType = 0;
            AddMapEntry(new Color(36, 36, 53));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Shingles>());
            return true;
        }
    }
}
