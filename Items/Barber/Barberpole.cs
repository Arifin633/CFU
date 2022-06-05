using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Barberpole : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Barber/Barberpole";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barber's Pole");
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
            Item.createTile = ModContent.TileType<Tiles.Barberpole>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.SilverBar, 2)
            .AddTile(TileID.GlassKiln)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.TungstenBar, 2)
            .AddTile(TileID.GlassKiln)
            .Register();
        }
    }
}
