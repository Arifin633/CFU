using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MirrorMahogany : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Mirrors/MirrorMahogany";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rich Mahogany Mirror");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = 0;
            Item.createTile = ModContent.TileType<Tiles.Mirrors>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RichMahogany, 10)
            .AddIngredient(ItemID.Glass, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
