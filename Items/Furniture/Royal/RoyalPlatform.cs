using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RoyalPlatform : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Royal/RoyalPlatform";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Platform");
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
            Item.createTile = ModContent.TileType<Tiles.Platforms>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddTile(ModContent.TileType<Tiles.SpinningWheel>())
            .Register();
        }
    }
}
