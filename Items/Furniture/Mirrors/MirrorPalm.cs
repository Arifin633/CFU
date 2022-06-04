using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MirrorPalm : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Mirrors/MirrorPalm";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palm Wood Mirror");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.createTile = ModContent.TileType<Tiles.Mirrors>();
            Item.placeStyle = 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PalmWood, 10)
            .AddIngredient(ItemID.Glass, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
