using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Paper : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Paper";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paper");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Paper>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddRecipeGroup(RecipeGroupID.Wood)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
