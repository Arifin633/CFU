using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class StatueAzura : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Statues/StatueAzura";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Height = 7;
            TileObjectData.newTile.Origin = new Point16(1, 6);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));
            DustType = DustID.Stone;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.StatueAzura>());
        }
    }
}
