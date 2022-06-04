using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MirrorEbon : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Mirrors/MirrorEbon";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonwood Mirror");
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
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = 0;
            Item.createTile = ModContent.TileType<Tiles.Mirrors>();
            Item.placeStyle = 4;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ebonwood, 10)
            .AddIngredient(ItemID.Glass, 5)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
