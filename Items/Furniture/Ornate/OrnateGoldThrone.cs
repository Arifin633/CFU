using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnateGoldThrone : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Ornate/OrnateGoldThrone";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tall Gold Throne");
            Tooltip.SetDefault("'For the exceptionally regal and the exceptionally tall.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.OrnateThrones>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 15)
            .AddIngredient(ItemID.Silk, 15)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
