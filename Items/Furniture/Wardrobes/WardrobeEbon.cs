using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WardrobeEbon : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Wardrobes/WardrobeEbon";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonwood Wardrobe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Wardrobes>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ebonwood, 20)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
