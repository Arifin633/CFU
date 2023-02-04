using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class BagSeaOats : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Magic Seed Bags/BagSeaOats";
        public override void SetStaticDefaults() => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<Tiles.MiracleSeaOats>();
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.value = 0;
            Item.rare = ItemRarityID.Green;
            Item.tileBoost = 3;
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
