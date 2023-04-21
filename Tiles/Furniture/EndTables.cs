using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class EndTables : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/EndTables";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.WorkBenches };
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            switch (frameX / 54)
            {
                case 16: /* Meteor */
                    drawData.glowTexture = ModContent.Request<Texture2D>(Texture + "Glow").Value;
                    drawData.glowSourceRect = new Rectangle(frameX, frameY, drawData.tileWidth, drawData.tileHeight);
                    drawData.glowColor = CFUTileDraw.MeteorGlow;
                    break;
                case 24: /* Martian */
                    drawData.glowTexture = ModContent.Request<Texture2D>(Texture + "Glow").Value;
                    drawData.glowSourceRect = new Rectangle(frameX, frameY, drawData.tileWidth, drawData.tileHeight);
                    drawData.glowColor = CFUTileDraw.MartianGlow;
                    break;
            }
        }        
    }
}
