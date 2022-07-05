using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticPlatform : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mystic/MysticPlatform";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Platform");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Platforms>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<Items.Stardust>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
