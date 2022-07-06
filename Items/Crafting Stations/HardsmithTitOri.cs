using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class HardsmithTitOri : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Crafting Stations/HardsmithTitOri";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hardmode Blacksmith's Forge");
            Tooltip.SetDefault("Used for smelting ore\nUsed to craft items from metal bars");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.Hardsmith>();
            Item.placeStyle = 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Hellsmith>())
            .AddIngredient(ItemID.TitaniumOre, 30)
            .AddIngredient(ItemID.OrichalcumAnvil)
            .AddTile(TileID.WorkBenches)
            .Register();

            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Items.Blacksmith>())
            .AddIngredient(ItemID.TitaniumForge, 1)
            .AddIngredient(ItemID.OrichalcumAnvil, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
