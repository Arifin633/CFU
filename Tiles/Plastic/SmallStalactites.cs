using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class SmallStalactites : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/SmallStalactites";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]{ 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(24);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(27);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(30);
            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
            TileObjectData.addSubTile(33);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorTop = AnchorData.Empty;
            TileObjectData.addAlternate(36);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(128, 128, 128));

            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.StoneSmallStalactite>(),
                             ModContent.ItemType<Items.HallowedSmallStalactite>(),
                             ModContent.ItemType<Items.CorruptSmallStalactite>(),
                             ModContent.ItemType<Items.CrimsonSmallStalactite>(),
                             ModContent.ItemType<Items.SandstoneSmallStalactite>(),
                             ModContent.ItemType<Items.GraniteSmallStalactite>(),
                             ModContent.ItemType<Items.MarbleSmallStalactite>(),
                             ModContent.ItemType<Items.HoneySmallStalactite>(),
                             ModContent.ItemType<Items.HallowedIceSmallStalactite>(),
                             ModContent.ItemType<Items.CorruptIceSmallStalactite>(),
                             ModContent.ItemType<Items.CrimsonIceSmallStalactite>(),
                             ModContent.ItemType<Items.IceSmallStalactite>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameX / 54)]);
            return true;
        }
    }
}
