using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class WorldMap : ModItem
    {
        public override string Texture => "CFU/Textures/Items/WorldMap";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("World Map");
            Tooltip.SetDefault("'It's old.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.WorldMap>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Paper>(), 10)
            .AddTile(ModContent.TileType<Tiles.Printer>())
            .Register();
        }
    }
}
