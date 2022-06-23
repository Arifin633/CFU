using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class LimestoneBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LimestoneBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type);
            Main.tileBlockLight[Type] = true;
            DustType = 0;
            AddMapEntry(new Color(160, 156, 146));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.LimestoneBrick>());
            return true;
        }
    }
}
