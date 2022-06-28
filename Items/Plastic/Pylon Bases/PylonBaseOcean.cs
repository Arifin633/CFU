using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PylonBaseOcean : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/Pylon Bases/PylonBaseOcean";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decorative Ocean Pylon Base");
            Tooltip.SetDefault("'*A plastic replica'\n'Crystal not included'");
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
            Item.createTile = ModContent.TileType<Tiles.PylonBases>();
            Item.placeStyle = 4;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SandBlock, 5)
            .AddIngredient(ItemID.Coral, 2)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}
