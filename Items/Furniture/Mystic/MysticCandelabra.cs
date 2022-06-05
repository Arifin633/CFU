using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticCandelabra : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Mystic/MysticCandelabra";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Candelabra");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Candelabras>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 5)
            .AddIngredient(ItemID.DemonTorch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
