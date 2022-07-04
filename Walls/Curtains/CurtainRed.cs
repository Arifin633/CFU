using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class CurtainRed : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Curtains/CurtainRed";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(135, 55, 40));
            DustType = DustID.GemRuby;
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.CurtainRed>();
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUTileDraw.CurtainDrawEdges(i, j, spriteBatch, Type, Texture);
        }
    }
}
