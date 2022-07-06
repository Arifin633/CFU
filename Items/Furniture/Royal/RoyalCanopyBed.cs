using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RoyalCanopyBed : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Royal/RoyalCanopyBed";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Canopy Bed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.CanopyBeds>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 35)
            .AddIngredient(ItemID.Silk, 10)
            .AddTile(ModContent.TileType<Tiles.SpinningWheel>())
            .Register();
        }
    }
}
