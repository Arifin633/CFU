using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class SunflowerWall : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Blocks/SunflowerWall";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunflower Wall");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 40;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.SunflowerWall>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(32)
            .AddIngredient(ItemID.Sunflower)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
