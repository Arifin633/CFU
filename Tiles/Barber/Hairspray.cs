using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Hairspray : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Barber/Hairspray";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(133, 213, 247));
            DustType = DustID.Glass;
            HitSound = SoundID.Shatter;
        }

        public override bool RightClick(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX >= 144)
                CFUtils.ShiftTileX(i, j, 0, set: true);
            else
                CFUtils.ShiftTileX(i, j, 18);
            return true;
        }
    }
}
