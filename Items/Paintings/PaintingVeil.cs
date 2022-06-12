using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class PaintingVeil : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Paintings/PaintingVeil";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Person Under a Veil");
            Tooltip.SetDefault("'Chadwick M. deVries'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 10000;
            Item.createTile = ModContent.TileType<Tiles.Paintings3x2>();
            Item.placeStyle = 1;
        }
    }
}

