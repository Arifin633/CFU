using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Minifridge : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kitchen/Minifridge";
        public override string HighlightTexture => "CFU/Textures/Tiles/Kitchen/MinifridgeHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicChest[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Containers };
            ChestDrop = ModContent.ItemType<Items.Minifridge>();
            AddMapEntry(new Color(81, 81, 89), this.GetLocalization("MapEntry"), MapChestName);
            DustType = -1;
        }
        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public static string MapChestName(string name, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 2));
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);

            if (Main.chest[chest].name is "" or "Minifridge")
                return name;

            return name + ": " + Main.chest[chest].name;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Minifridge>());
            Chest.DestroyChest(i, j);
        }

        public override bool RightClick(int i, int j)
        {
            CFUtils.OpenChest(i, j, 2);
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;

            Tile tile = Main.tile[i, j];
            int left = (tile.TileFrameX != 0) ? (i - 1) : i;
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconText = Main.chest[chest].name;

            if (Main.chest[chest].name is "" or "Minifridge")
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Minifridge>();
                player.cursorItemIconText = "";
            }

        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }
    }
}
