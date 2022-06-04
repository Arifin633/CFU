using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class RookWhite : ModItem
    {public override string Texture =>"CFU/Textures/Items/Chess Pieces/RookWhite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Rook");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = 0;
            Item.createTile = ModContent.TileType<Tiles.ChessPieces>();
            Item.placeStyle = 12;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Marble, 20)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
