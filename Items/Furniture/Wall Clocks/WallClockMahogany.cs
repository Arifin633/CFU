using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallClockMahogany : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Clocks/WallClockMahogany";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mahogany Clock");
            Tooltip.SetDefault("'Hanging from the wall.'");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.WallClocks>();
            Item.placeStyle = 20;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IronBar, 3)
            .AddIngredient(ItemID.Glass, 6)
              .AddIngredient(ItemID.RichMahogany, 5)
            .AddTile(TileID.Sawmill)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.LeadBar, 3)
            .AddIngredient(ItemID.Glass, 6)
             .AddIngredient(ItemID.RichMahogany, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
