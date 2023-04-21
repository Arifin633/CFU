using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Clocks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Clocks";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ClocksHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.Clock[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.GrandfatherClocks };
            AddMapEntry(new Color(127, 92, 69));
            DustType = -1;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool RightClick(int x, int y)
        {
            CFUtils.PrintTime();
            return true;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinClock>(),
              ModContent.ItemType<Items.MysticClock>(),
              ModContent.ItemType<Items.RoyalClock>(),
              ModContent.ItemType<Items.SandstoneClock>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 92)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }
    }
}
