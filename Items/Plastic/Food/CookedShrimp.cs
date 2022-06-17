using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CookedShrimp : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/Food/CookedShrimp";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decorative Cooked Shrimp");
            Tooltip.SetDefault("'*A plastic replica'");
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
            Item.createTile = ModContent.TileType<Tiles.Food2x1>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CookedShrimp)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .Register();

            Mod.CreateRecipe(ItemID.CookedShrimp)
            .AddIngredient(this)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .Register();
        }
    }
}
