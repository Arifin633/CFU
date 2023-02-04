using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Workbenches : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Workbenches";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.WorkBenches };
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinWorkbench>(),
                             ModContent.ItemType<Items.MysticWorkbench>(),
                             ModContent.ItemType<Items.RoyalWorkbench>(),
                             ModContent.ItemType<Items.SandstoneWorkbench>(),
                             ModContent.ItemType<Items.RushWorkbench>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameX / 36)]);
        }
    }
}
