using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MintJar : ModItem
    {public override string Texture =>"CFU/Textures/Items/MintJar";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jar O' Mints");
            Tooltip.SetDefault("'Purely for decorational purposes.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.MintJar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bottle)
            .AddIngredient(ItemID.HoneyBlock, 4)
            .Register();
        }
    }
}
