using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LargeGlobe : ModItem
    {
        public override string Texture => "CFU/Textures/Items/LargeGlobe";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Globe");
            Tooltip.SetDefault("'Of a 2D world?'");
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
            Item.createTile = ModContent.TileType<Tiles.LargeGlobe>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 30)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
