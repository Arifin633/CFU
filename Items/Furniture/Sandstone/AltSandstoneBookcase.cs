using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class AltSandstoneBookcase : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/AltSandstoneBookcase";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Bookcase");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Bookcases>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.AltSandstoneBrick>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
