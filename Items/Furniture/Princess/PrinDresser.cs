using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PrinDresser : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Princess/PrinDresser";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Princess Dresser");
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
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Dressers>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 1)
            .AddIngredient(ItemID.Pearlwood, 16)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
