using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LifeFruit : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/LifeFruit";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decorative Life Fruit");
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
            Item.createTile = ModContent.TileType<Tiles.LifeFruit>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.LifeFruit, 1)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .Register();

            Mod.CreateRecipe(ItemID.LifeFruit)
            .AddIngredient(this)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .Register();
        }
    }
}
