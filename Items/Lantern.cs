using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Lantern : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Lantern";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hanging Lamp");
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
            Item.createTile = ModContent.TileType<Tiles.Lantern>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 3)
                .AddIngredient(ItemID.Torch, 1)
                .AddIngredient(ItemID.Glass, 3)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 3)
                .AddIngredient(ItemID.Torch, 1)
                .AddIngredient(ItemID.Glass, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
