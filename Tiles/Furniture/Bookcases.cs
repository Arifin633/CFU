using Microsoft.Xna.Framework;
using Terraria;
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
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bookcase");
            AddMapEntry(new Color(181, 172, 190), name);
            DustType = -1;
            AdjTiles = new int[] { 101 };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinBookcase>(),
                             ModContent.ItemType<Items.MysticBookcase>(),
                             ModContent.ItemType<Items.RoyalBookcase>(),
                             ModContent.ItemType<Items.AltSandstoneBookcase>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 74)]);
        }
    }
}
