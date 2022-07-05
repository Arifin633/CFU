using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class SandstoneCandelabra : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/SandstoneCandelabra";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Candelabra");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Candelabras>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 5)
            .AddIngredient(ModContent.ItemType<Items.SandstoneTorch>(), 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}