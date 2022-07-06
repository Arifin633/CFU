using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class Fishhook : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Fishhook";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fishhook");
            Tooltip.SetDefault("Right click to hang a fish");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Fishhook>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
