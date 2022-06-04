using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class WallClockAltSandstone : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Wall Clocks/WallClockAltSandstone";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstone Clock");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.WallClocks>();
            Item.placeStyle = 28;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 5)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();

            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 5)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ItemID.LeadBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
