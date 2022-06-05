using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StglDryad : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Stained Glass Windows/StglDryad";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stained Glass Window");
            Tooltip.SetDefault("'It depicts the Dryad.'");
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
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.StglDryad>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Amethyst, 1)
            .AddIngredient(ItemID.Topaz, 1)
            .AddIngredient(ItemID.Sapphire, 1)
            .AddIngredient(ItemID.Emerald, 1)
            .AddIngredient(ItemID.Ruby, 1)
            .AddIngredient(ItemID.Diamond, 1)
            .AddIngredient(ItemID.Glass, 20)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
