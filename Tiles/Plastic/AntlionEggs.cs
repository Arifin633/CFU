using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
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
        }
        
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 20)
                frameCounter = 0;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (((Main.tile[i, j].TileFrameX % 36) == 0) &&
                (Main.tile[i, j].TileFrameY == 0))
            {
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
            }
        }
        
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.AntlionEggs>());
        }
    }
}
