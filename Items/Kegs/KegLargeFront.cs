using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class KegLargeFront : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kegs/KegLargeFront";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Forward-facing Keg");
            Tooltip.SetDefault("Used for brewing ale");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.KegLargeFront>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}