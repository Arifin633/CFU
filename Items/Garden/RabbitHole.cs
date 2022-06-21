using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RabbitHole : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Garden/RabbitHole";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rabbit Hole");
            Tooltip.SetDefault("'An elegant property located in a garden near sources\nof food and water, yet capturing the rough and tough\ncountry-feel of European-style rabbit architecture.\nYear built: 1854\n4 beds\n2 baths\nIncludes pre-built kitchen with appliances.'");
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
            Item.createTile = ModContent.TileType<Tiles.RabbitHole>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.DirtBlock, 10)
            .AddIngredient(ItemID.Bunny, 1)
            .Register();
        }
    }
}
