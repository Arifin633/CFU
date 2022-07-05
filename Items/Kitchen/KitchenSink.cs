using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class KitchenSink : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kitchen/KitchenSink";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kitchen Sink");
            Tooltip.SetDefault("'Can be installed in a Kitchen Counter'");
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
            Item.createTile = ModContent.TileType<Tiles.KitchenSinks>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
