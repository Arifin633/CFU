using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Walls
{
    public class CurtainBlue : ModWall
    {
        public override string Texture => "CFU/Textures/Walls/Curtains/CurtainBlue";
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(44, 67, 147));
            DustType = DustID.GemSapphire;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CFUTileDraw.CurtainDrawEdges(i, j, spriteBatch, Type, Texture);
        }
    }
}
