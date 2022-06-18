using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class DeerHead : ModItem
    {
        public override string Texture => "CFU/Textures/Items/DeerHead";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deer Head");
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
            Item.value = 10000;
            Item.createTile = ModContent.TileType<Tiles.DeerHead>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
        }
    }
}
