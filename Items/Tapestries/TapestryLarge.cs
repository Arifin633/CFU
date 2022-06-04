using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class TapestryLarge : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Tapestries/TapestryLarge";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tapestry");
            Tooltip.SetDefault("'Depicts the family tree of King Jacques'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.TapestriesLarge>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 10)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}
