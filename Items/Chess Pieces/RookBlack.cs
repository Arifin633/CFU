using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class RookBlack : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Chess Pieces/RookBlack";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Rook");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.ChessPieces>();
            Item.placeStyle = 13;
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
