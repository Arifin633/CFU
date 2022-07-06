using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class HangingBlinkroot : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Kitchen/HangingBlinkroot";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hanging Blinkroot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.HangingHerbs>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Blinkroot)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
