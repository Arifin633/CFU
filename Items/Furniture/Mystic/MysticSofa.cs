using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticSofa : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mystic/MysticSofa";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Sofa");
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
            Item.createTile = ModContent.TileType<Tiles.Sofas>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
