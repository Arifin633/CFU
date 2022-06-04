using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class AltSandstoneWorkbench : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/AltSandstoneWorkbench";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstone Work Bench");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Workbenches>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 10)
            .Register();
        }
    }
}
