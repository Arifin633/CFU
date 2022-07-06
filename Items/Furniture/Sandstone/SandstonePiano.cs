using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class SandstonePiano : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/SandstonePiano";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Piano");
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
            Item.createTile = ModContent.TileType<Tiles.Pianos>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 15)
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ItemID.Book)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
