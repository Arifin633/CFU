using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Horus : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Horus";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Horus");
            Tooltip.SetDefault("Holds religious (and decorative) connotation");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 20000;
            Item.createTile = ModContent.TileType<Tiles.Horus>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>(), 6)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}

