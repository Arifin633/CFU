using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RubblemakerPlaceholder : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Rubblemaker/RubblemakerPlaceholder";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rubblemaker 2.0");
            Tooltip.SetDefault("Used with materials to place matching piles, stalactites, stalagmites, and pots\n<right> to toggle placement type and size\nPress Up/Down to cycle through styles\n'Not a piledriver nor a placeinator: It's a Rubblemaker'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.value = 0;
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerSmall)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerMedium)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerLarge)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
