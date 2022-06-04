using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Printer : ModItem
    {public override string Texture =>"CFU/Textures/Items/Crafting Stations/Printer";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Printer");
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
            Item.createTile = ModContent.TileType<Tiles.Printer>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wire, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddIngredient(ModContent.ItemType<Items.Paper>(), 5)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
