using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class GunRack : ModItem
    {public override string Texture =>"CFU/Textures/Items/GunRack";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gun Rack");
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
            Item.createTile = ModContent.TileType<Tiles.GunRack>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
