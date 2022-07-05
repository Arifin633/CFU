using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MiracleBlinkroot : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/Herbs/MiracleBlinkroot";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miracle Blinkroot");
            Tooltip.SetDefault("'Can grow anywhere!'");
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
            Item.createTile = ModContent.TileType<Tiles.MiracleHerbs>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Blinkroot)
            .AddTile(ModContent.TileType<Tiles.CultivationBox>())
            .Register();
        }
    }
}
