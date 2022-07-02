using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Food1x1 : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Food/Food1x1";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 22 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sugar Cookie");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("GingerbreadCookie");
            name.SetDefault("Gingerbread Cookie");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("Ale");
            name.SetDefault("Ale");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("Sake");
            name.SetDefault("Sake");
            AddMapEntry(new Color(224, 219, 236), name);
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 18);

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.SugarCookie>(),
                             ModContent.ItemType<Items.GingerbreadCookie>(),
                             ModContent.ItemType<Items.Ale>(),
                             ModContent.ItemType<Items.Sake>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, styles[(Main.tile[i, j].TileFrameX / 18)]);
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
            => offsetY = -6;
    }
}
