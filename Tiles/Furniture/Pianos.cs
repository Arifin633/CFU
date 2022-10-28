using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Pianos : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Pianos";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Piano");
            AddMapEntry(new Color(127, 92, 69), name);
            DustType = -1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinPiano>(),
                             ModContent.ItemType<Items.MysticPiano>(),
                             ModContent.ItemType<Items.RoyalPiano>(),
                             ModContent.ItemType<Items.SandstonePiano>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 38)]);
        }
    }
}
