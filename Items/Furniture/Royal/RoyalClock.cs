using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RoyalClock : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Royal/RoyalClock";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Clock");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Clocks>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddTile(ModContent.TileType<Tiles.SpinningWheel>())
            .Register();
        }
    }
}
