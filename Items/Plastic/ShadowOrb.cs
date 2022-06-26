using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class ShadowOrb : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/ShadowOrb";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Orb");
            Tooltip.SetDefault("'*A plastic replica'");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.ShadowOrbCrimsonHeart>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.EbonstoneBlock, 100)
            .AddIngredient(ItemID.SoulofNight, 5)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}
