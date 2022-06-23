using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class LimestoneSlabWall : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Blocks/LimestoneSlabWall";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limestone Slab Wall");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            Item.createWall = ModContent.WallType<Walls.LimestoneSlabWall>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ModContent.ItemType<Items.LimestoneSlab>())
            .AddTile(TileID.WorkBenches)
            .Register();

            Mod.CreateRecipe(ModContent.ItemType<Items.LimestoneSlab>())
            .AddIngredient(this, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
