using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Keg : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kegs/Keg";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileTable[Type] = false;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Keg");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Kegs };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ItemID.Keg);
        }
    }
}
