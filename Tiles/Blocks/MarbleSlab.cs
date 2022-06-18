using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class MarbleSlab : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/MarbleSlab";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type);
            Main.tileBlockLight[Type] = true;
            DustType = 0;
            AddMapEntry(new Color(168, 178, 204));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.MarbleSlab>());
            return true;
        }
    }
}
