using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class CultivationBox : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/CultivationBox";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            HitSound = SoundID.Shatter;
            DustType = -1;
            AddMapEntry(new Color(133, 213, 247));
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            type = (Main.rand.NextBool(3))
                ? DustID.Glass : DustID.Grass;
            return true;
        }
    }
}
