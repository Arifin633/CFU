using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class KnightBlack : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Chess Pieces/KnightBlack";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Knight");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.ChessPieces>();
            Item.placeStyle = 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Granite, 20)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
