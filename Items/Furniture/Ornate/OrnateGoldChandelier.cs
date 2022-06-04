using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class OrnateGoldChandelier : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Ornate/OrnateGoldChandelier";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ornate Gold Chandelier");
            Tooltip.SetDefault("'If one of those 'normal' gold chandeliers is not gold enough'");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.OrnateChandeliers>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.GoldBar, 8)
            .AddIngredient(ItemID.Torch, 8)
            .AddIngredient(ItemID.Chain, 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
