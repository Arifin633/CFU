using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CrimsonIceStalactite : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Plastic/Stalactites/CrimsonIceStalactite";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Ice Stalactite");
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
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Stalactites>();
            Item.placeStyle = 30;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedIceBlock)
            .AddTile(ModContent.TileType<Tiles.Printer3D>())
            .AddConsumeItemCallback(ChadsFurnitureUpdated.CFUtils.Print)
            .Register();
        }
    }
}
