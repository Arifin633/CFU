using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class PlantPots : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Garden/PlantPots";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 22 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            DustType = -1;
            AddMapEntry(new Color(146, 81, 68));
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short _1, ref short _2)
        {
            offsetY = -4;
        }
    }
}
