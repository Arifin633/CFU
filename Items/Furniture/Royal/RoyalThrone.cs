using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RoyalThrone : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Royal/RoyalThrone";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Throne");
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
            Item.createTile = ModContent.TileType<Tiles.Throne>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 7)
            .AddIngredient(ItemID.Silk, 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}