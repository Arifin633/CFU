// using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
    public class AltSandstoneTorch : ModItem
    {
        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/AltSandstoneTorch";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Torch");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 12;
            Item.maxStack = 99;
            Item.holdStyle = 1;
            Item.noWet = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Torches>();
            Item.value = 0;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches;
        }


        /* All of this works way too badly and is not really necessary.
           TODO: Maybe figure this out later.
        /* public override void HoldItem(Player player)
        {
            if (Main.rand.NextBool(player.itemAnimation > 0 ? 40 : 80))
            {
                Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.DesertTorch, 0, 0, 0, new Color(1f, 0.5f, 0f));
            }

            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 1f, 0.5f, 0f);
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
            {
                Lighting.AddLight(Item.Center, 1f, 0.5f, 0f);
            }
        } */

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            dryTorch = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
            .AddIngredient(ItemID.Torch, 3)
            .AddIngredient(ModContent.ItemType<Items.AltSandstoneBrick>(), 1)
            .Register();
        }
    }
}
