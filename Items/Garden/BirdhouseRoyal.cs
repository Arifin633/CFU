using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class BirdhouseRoyal : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Garden/BirdhouseRoyal";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Birdhouse");
            Tooltip.SetDefault("'Any bird's dream home.'");
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
            Item.createTile = ModContent.TileType<Tiles.Birdhouses>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddIngredient(ItemID.GoldBird, 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}