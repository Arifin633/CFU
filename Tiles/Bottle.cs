using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Bottle : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Bottle";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bottle");
            AddMapEntry(new Color(133, 213, 247), name);
            DustType = DustID.Glass;
            HitSound = SoundID.Shatter;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<Items.Bottle>());
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
