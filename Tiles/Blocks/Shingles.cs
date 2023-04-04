using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class Shingles : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/Shingles";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            DustType = DustID.Asphalt;
            AddMapEntry(new Color(36, 36, 53));
        }
    }
}
