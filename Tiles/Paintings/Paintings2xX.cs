using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Paintings2xX : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Paintings/Paintings2xX";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.newSubTile.Height = 4;
            TileObjectData.newSubTile.Origin = new Point16(1, 1);
            TileObjectData.newSubTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addSubTile(5);
            TileObjectData.addTile(Type);
            DustType = 0;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Painting");
            AddMapEntry(new Color(191, 142, 111), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PaintingMount>(),
                             ModContent.ItemType<Items.PaintingTree>(),
                             ModContent.ItemType<Items.PaintingJaak>(),
                             ModContent.ItemType<Items.PaintingSunflower>(),
                             ModContent.ItemType<Items.PaintingWater>(),
                             ModContent.ItemType<Items.PaintingFlute>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 36)]);
        }
    }
}