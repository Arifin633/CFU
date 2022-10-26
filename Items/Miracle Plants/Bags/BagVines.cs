using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class BagVines : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Miracle Plants/Bags/BagVines";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Seed Bag (Vine)");
            Tooltip.SetDefault("Used with seeds to place matching plants\n<right> while holding to choose plant type\nPress Up/Down to cycle through styles\n'Can grow anywhere!'");
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

        public override bool AltFunctionUse(Player player)
        {
            if (UI.UISystem.Interface.CurrentState != null)
            {
                UI.UISystem.Interface.SetState(null);
            }
            else
            {
                UI.UISystem.Interface.SetState(UI.UISystem.State);
            }
            return false;
        }
    }
}
