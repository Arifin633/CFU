using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Bookcases : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Bookcases";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Bookcases };
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bookcase");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = -1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinBookcase>(),
                             ModContent.ItemType<Items.MysticBookcase>(),
                             ModContent.ItemType<Items.RoyalBookcase>(),
                             ModContent.ItemType<Items.SandstoneBookcase>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 74)]);
        }
    }
}
