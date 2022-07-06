using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class GnomeHouse : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Garden/GnomeHouse";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gnome House");
            Tooltip.SetDefault("'Not to be confused with a mushroom, which it looks like'");
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
            Item.createTile = ModContent.TileType<Tiles.GnomeHouse>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ClayBlock, 15)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}
