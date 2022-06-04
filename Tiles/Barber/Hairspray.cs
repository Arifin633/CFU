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
    {public override string Texture =>"CFU/Textures/Tiles/Barber/Hairspray";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 18;
            TileObjectData.addTile(Type);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bottle");
            AddMapEntry(new Color(133, 213, 247), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<Items.Hairspray>());
        }

        public override bool RightClick(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX >= 144)
                CFUtils.ShiftTileX(i, j, 1, 2, 18, true);
            else
                CFUtils.ShiftTileX(i, j, 1, 2, 18, false);
            return true;
        }
    }
}
