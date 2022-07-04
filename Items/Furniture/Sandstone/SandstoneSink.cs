using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class SandstoneSink : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/SandstoneSink";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Sink");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Sinks>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 6)
            .AddIngredient(ItemID.WaterBucket, 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
