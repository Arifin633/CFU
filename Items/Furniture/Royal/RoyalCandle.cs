using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RoyalCandle : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Royal/RoyalCandle";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Candle");
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
            Item.createTile = ModContent.TileType<Tiles.Candles>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Torch, 1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(ModContent.TileType<Tiles.SpinningWheel>())
            .Register();
        }
    }
}
