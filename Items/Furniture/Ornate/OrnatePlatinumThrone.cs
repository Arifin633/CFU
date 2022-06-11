using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnatePlatinumThrone : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Ornate/OrnatePlatinumThrone";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tall Platinum Throne");
            Tooltip.SetDefault("'For the exceptionally regal and the exceptionally tall.'");
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
            Item.createTile = ModContent.TileType<Tiles.OrnateThrones>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 15)
            .AddIngredient(ItemID.Silk, 15)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}