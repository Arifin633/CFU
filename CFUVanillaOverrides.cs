using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    public class GlobalCFUItem : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.Keg)
                Item.createTile = ModContent.TileType<Tiles.Keg>();
        }
    }
}
