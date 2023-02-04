using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Wardrobes : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Wardrobes";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/WardrobesHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicDresser[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.Dressers };
            AddMapEntry(new Color(127, 92, 69));
            DustType = -1;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Main.playerInventory = false;
            player.chest = -1;
            Recipe.FindRecipes();
            player.SetTalkNPC(-1);
            Main.npcChatCornerItem = 0;
            Main.npcChatText = "";
            Main.interactedDresserTopLeftX = (i - (Main.tile[i, j].TileFrameX % 54) / 18);
            Main.interactedDresserTopLeftY = (j - Main.tile[i, j].TileFrameY / 18);
            Main.OpenClothesWindow();
            return true;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.WardrobeEbon>(),
              ModContent.ItemType<Items.WardrobeBoreal>(),
              ModContent.ItemType<Items.WardrobeMahogany>(),
              ModContent.ItemType<Items.WardrobePalm>(),
              ModContent.ItemType<Items.WardrobePearl>(),
              ModContent.ItemType<Items.WardrobeShade>(),
              ModContent.ItemType<Items.WardrobeWood>(),
              ModContent.ItemType<Items.WardrobePrincess>(),
              ModContent.ItemType<Items.WardrobeSandstone>(),
              ModContent.ItemType<Items.WardrobeAsh>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemID.FamiliarShirt;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, Styles[(frameX / 54)]);
        }
    }
}
