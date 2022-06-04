using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class MysticPiano : ModItem
    {public override string Texture =>"CFU/Textures/Items/Furniture/Mystic/MysticPiano";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Piano");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType<Tiles.Pianos>();
            Item.placeStyle = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Stardust>(), 15)
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ItemID.Book, 1)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
