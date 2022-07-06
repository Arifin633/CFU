using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StatueSkeletron : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Statues/StatueSkeletron";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeletron Collectable Inaction Figure");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Statues3x3>();
            Item.placeStyle = 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SkeletronTrophy)
            .Register();
        }
    }
}
