using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class BishopWhite : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Chess Pieces/BishopWhite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Bishop");
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
            Item.placeStyle = 4;
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
