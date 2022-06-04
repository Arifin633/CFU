using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class BarberpoleLamp : ModItem
    {public override string Texture =>"CFU/Textures/Items/Barber/BarberpoleLamp";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barber's Pole with Lamp");
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
            Item.createTile = ModContent.TileType<Tiles.BarberpoleLamp>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Glass, 10)
            .AddIngredient(ItemID.SilverBar, 2)
            .AddTile(TileID.GlassKiln)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.Glass, 10)
            .AddIngredient(ItemID.TungstenBar, 2)
            .AddTile(TileID.GlassKiln)
            .Register();
        }
    }
}
