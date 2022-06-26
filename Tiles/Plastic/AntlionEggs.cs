using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class AntlionEggs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/AntlionEggs";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(230, 215, 195));
            TileID.Sets.DisableSmartCursor[Type] = true;
            AnimationFrameHeight = 36;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short x, ref short y)
        {
            offsetY = 2;
        }
        
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 20)
            {
                frameCounter = 0;
                frame = ++frame % 4;
            }
        }
        
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.AntlionEggs>());
        }
    }
}
