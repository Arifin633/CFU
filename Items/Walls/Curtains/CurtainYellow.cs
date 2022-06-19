using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class CurtainYellow : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Walls/Curtains/CurtainYellow";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Curtain");
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
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.CurtainYellow>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
            .AddIngredient(ItemID.Silk, 1)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}
