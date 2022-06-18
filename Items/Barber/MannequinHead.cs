using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MannequinHead : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Barber/MannequinHead";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mannequin Head");
            Tooltip.SetDefault("'Right-click after placing to change hairstyle'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.MannequinHead>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wood, 10)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
