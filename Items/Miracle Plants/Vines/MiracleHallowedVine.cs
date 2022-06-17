using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MiracleHallowedVine : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/Vines/MiracleHallowedVine";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miracle Hallowed Vine");
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
            Item.createTile = ModContent.TileType<Tiles.MiracleHallowedVine>();
        }
        public override void AddRecipes()
        {
            CreateRecipe(10)
            .AddIngredient(ItemID.VineRope, 10)
            .AddIngredient(ItemID.HallowedSeeds)
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}