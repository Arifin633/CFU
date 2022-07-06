using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CabinetGlass : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Cabinets/CabinetGlass";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Cabinet");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Cabinets>();
            Item.placeStyle = 11;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Glass, 10)
            .AddTile(TileID.GlassKiln)
            .Register();
        }
    }
}
