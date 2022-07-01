using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CoinStashSilver : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Coin Stashes/CoinStashSilver";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Coin Stash");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 1000;
            Item.createTile = ModContent.TileType<Tiles.CoinStashes>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 10)
                .AddIngredient(ModContent.ItemType<Items.Jute>(), 5)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ItemID.SilverCoin, 10)
                .AddIngredient(Type)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
