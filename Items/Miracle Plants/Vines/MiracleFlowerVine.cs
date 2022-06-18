using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MiracleFlowerVine : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/Vines/MiracleFlowerVine";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miracle Flower Vine");
            Tooltip.SetDefault("'Can grow anywhere!'");
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
            Item.createTile = ModContent.TileType<Tiles.MiracleFlowerVine>();
        }
        public override void AddRecipes()
        {
            CreateRecipe(10)
            .AddIngredient(ItemID.VineRope, 10)
            .AddIngredient(ItemID.GrassSeeds)
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}
