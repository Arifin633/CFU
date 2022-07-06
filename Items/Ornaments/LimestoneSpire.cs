using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LimestoneSpire : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Ornaments/LimestoneSpire";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limestone Spire");
            Tooltip.SetDefault("'A limestone ornament'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Spire>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.LimestoneBrick>(), 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
