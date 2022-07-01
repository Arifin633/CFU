using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StrangePlantGreen : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Garden/Plants/StrangePlantGreen";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Seed");
            Tooltip.SetDefault("'Grows a Strange Plant small enough to fit in a plant pot'");
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
            Item.value = 20;
            Item.createTile = ModContent.TileType<Tiles.StrangePlants>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.StrangePlant3, 1)
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}
