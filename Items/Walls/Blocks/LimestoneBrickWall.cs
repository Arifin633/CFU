using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LimestoneBrickWall : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Blocks/LimestoneBrickWall";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limestone Brick Wall");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
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
            Item.createWall = ModContent.WallType<Walls.LimestoneBrickWall>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ModContent.ItemType<Items.LimestoneBrick>())
            .AddTile(TileID.WorkBenches)
            .Register();

            Recipe.Create(ModContent.ItemType<Items.LimestoneBrick>())
            .AddIngredient(this, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
