using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Hairspray : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Barber/Hairspray";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hairspray");
            Tooltip.SetDefault("Right-click after placing if you dislike the smell");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType<Tiles.Hairspray>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bottle)
            .AddTile(TileID.Kegs)
            .Register();
        }
    }
}
