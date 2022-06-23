using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MarbleCavePot : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Pots/MarbleCavePot";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Pot");
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
            Item.createTile = ModContent.TileType<Tiles.Pots>();
            Item.placeStyle = 93;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ClayBlock, 5)
            .AddIngredient(ItemID.Marble, 5)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}