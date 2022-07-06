using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnateCounter : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kitchen/OrnateCounter";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ornate Kitchen Counter");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Counters>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 3)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddTile(TileID.Anvils)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 3)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
