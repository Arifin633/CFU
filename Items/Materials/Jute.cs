using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Jute : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Materials/Jute";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jute");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.value = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Rope, 5)
                .AddTile(TileID.Loom)
                .Register();

            CreateRecipe(2)
                .AddIngredient(ItemID.RopeCoil)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
