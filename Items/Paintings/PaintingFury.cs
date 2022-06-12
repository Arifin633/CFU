using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace CFU.Items
{
    public class PaintingFury : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Paintings/PaintingFury";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("100 Episodes of Fury's Modded Terraria!");
            Tooltip.SetDefault("A one-of-a-kind celebratory painting.\n'Chadwick M. deVries'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 1000000;
            Item.createTile = ModContent.TileType<Tiles.Paintings5x4>();
            Item.placeStyle = 1;
        }
    }
}

