using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WardrobeShade : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wardrobes/WardrobeShade";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadewood Wardrobe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Wardrobes>();
            Item.placeStyle = 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Shadewood, 20)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
