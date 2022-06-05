using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticClock : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mystic/MysticClock";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Clock");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Clocks>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 10)
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();

        }
    }
}
