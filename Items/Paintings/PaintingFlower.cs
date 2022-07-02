using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class PaintingFlower : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Paintings/PaintingFlower";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Very Lonely Flower");
            Tooltip.SetDefault("'Chadwick M. deVries'");
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
            // Item.value = 10000;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Paintings3x2>();
            Item.placeStyle = 2;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddTile(ModContent.TileType<Tiles.Easel>())
            .Register();
        }
    }
}

