using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticBed : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mystic/MysticBed";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Bed");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Beds>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
