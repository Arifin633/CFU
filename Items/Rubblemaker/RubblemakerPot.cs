using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
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
            Tooltip.SetDefault("Used with materials to place matching pots\n<right> to toggle placement type and size\nPress Up/Down to cycle through styles\n'Not a piledriver nor a placeinator: It's a Rubblemaker'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 22;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.createTile = TileID.PotsEcho;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.tileBoost = 3;
            Item.value = 0;
            Item.placeStyle = 0;
            Item.rare = ItemRarityID.Lime;
        }

        public override bool CanRightClick() => true;

        public override bool ConsumeItem(Player player) => false;

        public override void RightClick(Player player)
        {
            this.Item.SetDefaults(ModContent.ItemType<Items.RubblemakerPileSmall>());
            this.Item.stack = 1;
        }

        public override bool AltFunctionUse(Player player)
        {
            this.Item.SetDefaults(ModContent.ItemType<Items.RubblemakerPileSmall>());
            this.Item.stack = 1;
            SoundEngine.PlaySound(SoundID.Unlock);
            return false;
        }
        
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            float inventoryScale = Main.inventoryScale;
            Vector2 offset = new Vector2((12f * (inventoryScale * inventoryScale)), (-2f * (1f / (float)System.Math.Pow(inventoryScale, 3))));
            spriteBatch.Draw(ModContent.Request<Texture2D>("CFU/Textures/Items/Rubblemaker/RubblemakerBar").Value,
                             position + offset, new Rectangle(0, 0, 8, 20), drawColor, 0f, default, 1f, SpriteEffects.None, 0f);
        }
    }
}
