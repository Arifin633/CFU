using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PrinClock : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Princess/PrinClock";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Princess Clock");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Clocks>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ItemID.Pearlwood, 10)
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
