using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class Ladder : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Ladder";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ladder");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Ladder>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wood, 2)
            .AddTile(TileID.WorkBenches)
            .Register();

            Recipe.Create(ItemID.Wood, 2)
            .AddIngredient(this)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
