using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnatePlatinumChandelier : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Ornate/OrnatePlatinumChandelier";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ornate Platinum Chandelier");
            Tooltip.SetDefault("'If one of those 'normal' platinum chandeliers is not platinum enough'");
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
            Item.createTile = ModContent.TileType<Tiles.OrnateChandeliers>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 8)
            .AddIngredient(ItemID.Torch, 8)
            .AddIngredient(ItemID.Chain, 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
