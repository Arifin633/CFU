using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class SignTailor : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Signs/SignTailor";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tailor Sign");
            Tooltip.SetDefault("'Shows a roll of thread.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Signs>();
            Item.placeStyle = 7;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
