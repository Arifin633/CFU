using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class KegLargeFront : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kegs/KegLargeFront";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.KegLargeFront>() };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Kegs };
            AddMapEntry(new Color(191, 142, 111));
            DustType = DustID.WoodFurniture;
        }
    }
}
