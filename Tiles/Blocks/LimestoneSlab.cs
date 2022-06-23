using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

namespace CFU.Tiles
{
    public class LimestoneSlab : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LimestoneSlab";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type);
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLargeFrames[Type] = 1;
            DustType = 0;
            AddMapEntry(new Color(160, 156, 146));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.LimestoneSlab>());
            return true;
        }
    }
}
