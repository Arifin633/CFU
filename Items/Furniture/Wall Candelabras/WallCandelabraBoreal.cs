using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallCandelabraBoreal : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Wall Candelabras/WallCandelabraBoreal";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boreal Wood Wall Candelabra");
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
            Item.createTile = ModContent.TileType<Tiles.WallCandelabras>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BorealWood, 5)
            .AddIngredient(ItemID.IceTorch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
