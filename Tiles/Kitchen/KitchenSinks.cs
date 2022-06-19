using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class KitchenSinks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kitchen/KitchenSinks";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.Counters>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Kitchen Sink");
            AddMapEntry(new Color(81, 81, 89), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Sinks };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.KitchenSink>(),
                             ModContent.ItemType<Items.OrnateKitchenSink>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, styles[(frameX / 36)]);
        }
    }
}
