using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PaintableArmchair : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Paintable/PaintableArmchair";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armchair");
            Tooltip.SetDefault("'From the Paintables(R) Collection!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.BigChairs>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wood, 5)
            .AddIngredient(ItemID.Silk, 3)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
