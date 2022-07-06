using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CabinetObsidian : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Cabinets/CabinetObsidian";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Cabinet");
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
            Item.createTile = ModContent.TileType<Tiles.Cabinets>();
            Item.placeStyle = 22;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Obsidian, 7)
            .AddIngredient(ItemID.Hellstone, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
