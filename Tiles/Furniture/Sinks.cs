using Terraria;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CFU.Tiles
{
    public class Sinks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Sinks";
        public override void SetStaticDefaults()
        {
            // Main.tileSolidTop[Type] = true;
            // Main.tileTable[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.Sinks };
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sink");
            AddMapEntry(new Color(181, 172, 190), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinSink>(),
                             ModContent.ItemType<Items.MysticSink>(),
                             ModContent.ItemType<Items.RoyalSink>(),
                             ModContent.ItemType<Items.AltSandstoneSink>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 38)]);
        }
    }
}
