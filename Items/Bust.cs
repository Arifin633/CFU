using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Bust : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Bust";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bust");
            Tooltip.SetDefault("'It's some Roman Emperor or something'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Bust>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MarbleBlock, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
