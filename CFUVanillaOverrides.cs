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
            {
                Item.createTile = ModContent.TileType<Tiles.Keg>();
            }
            else if (Item.type == ItemID.BlackInk)
            {
                Item.useTurn = true;
                Item.autoReuse = true;
                Item.useAnimation = 15;
                Item.useTime = 10;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.consumable = true;
                Item.createTile = ModContent.TileType<Tiles.Ink>();
            }
        }
    }
}
