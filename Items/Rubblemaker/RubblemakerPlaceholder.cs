using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RubblemakerPlaceholder : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Rubblemaker/RubblemakerPlaceholder";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.createTile = TileID.Dirt; /* Placeholder so the description
                                              displays "Can be placed". */
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.value = 0;
            Item.placeStyle = 0;
            Item.tileBoost = 3;
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerSmall)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerMedium)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubblemakerLarge)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }

        /* This doesn't work because of loading order nonsense.
           Its working equivalent lives in `GlobalCFUItem'.
        public override void OnCreated (ItemCreationContext context)
        {
            this.Item.SetDefaults(ModContent.ItemType<Items.RubblemakerPileSmall>());
        } */
    }
}
