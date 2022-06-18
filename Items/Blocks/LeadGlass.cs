using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LeadGlass : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Blocks/LeadGlass";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Glass");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.LeadGlass>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
            .AddIngredient(ItemID.Glass, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
