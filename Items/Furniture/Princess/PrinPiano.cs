using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PrinPiano : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Princess/PrinPiano";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Princess Piano");
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
            Item.value = 500;
            Item.createTile = ModContent.TileType<Tiles.Pianos>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 1)
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ItemID.Pearlwood, 15)
            .AddIngredient(ItemID.Book, 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
