using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MiracleAshVine : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/Vines/MiracleAshVine";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miracle Ash Grass Vine");
            Tooltip.SetDefault("'Can grow anywhere!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.MiracleVines>();
            Item.placeStyle = 192;
        }
        public override void AddRecipes()
        {
            CreateRecipe(10)
            .AddIngredient(ItemID.VineRope, 10)
            // .AddIngredient(ItemID.AshGrassSeeds) TODO: Uncomment in 1.4.4
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}
