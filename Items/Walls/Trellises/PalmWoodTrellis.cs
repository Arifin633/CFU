using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class PalmWoodTrellis : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Trellises/PalmWoodTrellis";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palm Wood Trellis");
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
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.PalmWoodTrellis>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
            .AddIngredient(ItemID.PalmWood)
            .AddTile(TileID.WorkBenches)
            .Register();

            Recipe.Create(ItemID.PalmWood)
            .AddIngredient(this, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
