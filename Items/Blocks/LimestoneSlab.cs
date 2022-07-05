using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LimestoneSlab : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Blocks/LimestoneSlab";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limestone Slab");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.LimestoneSlab>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(25)
            .AddIngredient(ItemID.Coral)
            .AddIngredient(ItemID.StoneBlock, 25)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
