using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class EndTableObsidian : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/End Tables/EndTableObsidian";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian End Table");
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
            Item.createTile = ModContent.TileType<Tiles.EndTables>();
            Item.placeStyle = 22;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Obsidian, 8)
            .AddIngredient(ItemID.Hellstone, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
