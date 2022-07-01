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
            DustType = DustID.GemRuby;
            AddMapEntry(new Color(150, 150, 150));
        }

        public override bool Drop(int i, int j, ref int type)
        {
            type = ModContent.ItemType<Items.CurtainRoyal>();
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUTileDraw.CurtainDrawEdges(i, j, spriteBatch, Type, Texture);
        }
    }
}
