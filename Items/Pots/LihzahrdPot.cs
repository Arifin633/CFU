using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LihzahrdPot : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Pots/LihzahrdPot";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Pot");
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
            Item.placeStyle = 84;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ClayBlock, 5)
            .AddIngredient(ItemID.LihzahrdBrick, 5)
            .AddTile(TileID.Furnaces)
            .AddTile(TileID.LihzahrdFurnace)
            .Register();
        }
    }
}
