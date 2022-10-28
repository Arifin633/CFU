using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MossBrick : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Blocks/MossBrick";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decolored Moss Brick");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.MossBrick>();
        }

        public override void AddRecipes()
        {   /* TODO: Uncomment in 1.4.4
            CreateRecipe()
            .AddIngredient(ItemID.LavaMossBlock)
            .AddTile(TileID.Furnace)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.ArgonMossBlock)
            .AddTile(TileID.Furnace)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.KryptonMossBlock)
            .AddTile(TileID.Furnace)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.XenonMossBlock)
            .AddTile(TileID.Furnace)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.VioletMossBlock)
            .AddTile(TileID.Furnace)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RainbowMossBlock)
            .AddTile(TileID.Furnace)
            .Register(); */
        }
    }
}
