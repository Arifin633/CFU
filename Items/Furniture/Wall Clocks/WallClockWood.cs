using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallClockWood : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Clocks/WallClockWood";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wall Clock");
            Tooltip.SetDefault("'Hanging from the wall'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            ;
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.WallClocks>();
            Item.placeStyle = 0;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.Wood, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
