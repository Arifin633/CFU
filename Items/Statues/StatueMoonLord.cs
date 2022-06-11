using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class StatueMoonLord : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Statues/StatueMoonLord";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Lord Collectable Inaction Figure");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 8;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Statues3x4>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MoonLordTrophy)
            .Register();
        }
    }
}