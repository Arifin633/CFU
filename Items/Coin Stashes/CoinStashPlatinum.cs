using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CoinStashPlatinum : ModItem
    {
        public override string Texture =>"CFU/Textures/Items/Coin Stashes/CoinStashPlatinum";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Coin Stash");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 10000000;
            Item.createTile = ModContent.TileType<Tiles.CoinStashes>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumCoin, 10)
                .AddIngredient(ModContent.ItemType<Items.Jute>(), 5)
                .AddTile(TileID.WorkBenches)
                .Register();

            Mod.CreateRecipe(ItemID.PlatinumCoin, 10)
                .AddIngredient(Type)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
