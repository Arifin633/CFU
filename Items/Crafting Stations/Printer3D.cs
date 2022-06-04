using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Printer3D : ModItem
    {public override string Texture =>"CFU/Textures/Items/Crafting Stations/Printer3D";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("3D Printer");
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
            Item.createTile = ModContent.TileType<Tiles.Printer3D>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wire, 10)
            .AddIngredient(ItemID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.Wire, 10)
            .AddIngredient(ItemID.LeadBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
