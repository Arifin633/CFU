using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PylonBaseHallowed : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/Pylon Bases/PylonBaseHallowed";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decorative Hallow Pylon Base");
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
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PearlstoneBlock, 5)
            .AddIngredient(ItemID.CrystalShard, 5)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}