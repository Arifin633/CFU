using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MirrorPearl : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mirrors/MirrorPearl";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearlwood Mirror");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.Mirrors>();
            Item.placeStyle = 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Pearlwood, 10)
            .AddIngredient(ItemID.Glass, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
