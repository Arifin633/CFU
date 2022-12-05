using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class RubblemakerPot : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Rubblemaker/RubblemakerPot";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rubblemaker 2.0 (Pots)");
            Tooltip.SetDefault("Used with materials to place matching piles, stalactites, stalagmites, and pots\n<right> to toggle placement type and size\nPress Up/Down to cycle through styles\n'Not a piledriver nor a placeinator: It's a Rubblemaker'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.value = 0;
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            /* TODO: Uncomment in 1.4.4
            CreateRecipe()
            .AddIngredient(ItemID.RubbleMakerSmall)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubbleMakerMedium)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();

            CreateRecipe()
            .AddIngredient(ItemID.RubbleMakerLarge)
            .AddIngredient(ItemID.MythrilBar, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();*/
        }

        public override bool CanRightClick() => true;

        public override bool ConsumeItem(Player player) => false;

        public override void RightClick(Player player)
        {
            this.Item.SetDefaults(ModContent.ItemType<Items.RubblemakerPileSmall>());
            this.Item.stack = 1;
        }
    }
}
