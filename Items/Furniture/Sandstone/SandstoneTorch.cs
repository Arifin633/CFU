using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{

    public class SandstoneTorch : ModItem
    {

        public override string Texture => "CFU/Textures/Items/Furniture/Sandstone/SandstoneTorch";

        public override void AutoStaticDefaults()
        {
            TextureAssets.Item[this.Item.type] = ModContent.Request<Texture2D>(this.Texture, (AssetRequestMode)2);
            if (ModContent.RequestIfExists<Texture2D>(this.Texture + "Flame", out var flameTexture, (AssetRequestMode)2))
            {
                TextureAssets.ItemFlame[this.Item.type] = flameTexture;
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sandstone Torch");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.flame = true;
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

        public override void HoldItem(Player player)
        {
            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 1f, 0.5f, 0f);
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
            {
                Lighting.AddLight(Item.Center, 1f, 0.5f, 0f);
            }
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            dryTorch = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
            .AddIngredient(ItemID.Torch, 3)
            .AddIngredient(ModContent.ItemType<Items.SandstoneBrick>())
            .Register();
        }
    }
}
