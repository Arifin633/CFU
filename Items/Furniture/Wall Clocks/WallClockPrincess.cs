using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallClockPrincess : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Clocks/WallClockPrincess";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Princess Wall Clock");
            Tooltip.SetDefault("'Hanging from the wall'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.WallClocks>();
            Item.placeStyle = 25;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>())
            .AddIngredient(ItemID.Pearlwood, 5)
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();


        }
    }
}
