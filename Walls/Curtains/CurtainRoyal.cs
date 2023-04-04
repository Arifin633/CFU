using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class CurtainRoyal : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Curtains/CurtainRoyal";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(135, 40, 46));
            DustType = DustID.GemRuby;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUTileDraw.CurtainDrawEdges(i, j, spriteBatch, Type, Texture);
        }
    }
}
