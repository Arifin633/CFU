using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Posters : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Posters";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);
            DustType = -1;
            HitSound = SoundID.Grass;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddMapEntry(new Color(174, 162, 4));
            AddMapEntry(new Color(151, 107, 75));
            AddMapEntry(new Color(112, 170, 68));
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 54);

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.Poster>(),
                             ModContent.ItemType<Items.PosterTerraria>(),
                             ModContent.ItemType<Items.PosterMinecraft>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 54)]);
        }
    }
}
