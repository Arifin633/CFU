using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CultivationBox : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Crafting Stations/CultivationBox";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultivation Box");
            Tooltip.SetDefault("Used to craft plants");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.CultivationBox>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Terrarium, 1)
            .AddIngredient(ItemID.GrassSeeds, 1)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.Glass, 16)
            .AddIngredient(ItemID.GrassSeeds, 1)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
