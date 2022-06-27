using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LargePileSword : ModItem
    {
        public override string Texture =>"CFU/Textures/Items/Plastic/Large Piles/LargePileSword";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword in the Stone");
            Tooltip.SetDefault("'*A plastic replica'");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.LargePiles>();
            Item.placeStyle = 70;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.StoneBlock, 3)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}
