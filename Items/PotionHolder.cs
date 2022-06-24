using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class PotionHolder : ModItem
    {
        public override string Texture => "CFU/Textures/Items/PotionHolder";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potion Holder");
            Tooltip.SetDefault("Right click to place a potion");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.PotionHolder>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
