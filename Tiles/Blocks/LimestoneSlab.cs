using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CFU.Tiles
{
    public class LimestoneSlab : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LimestoneSlab";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLargeFrames[Type] = 1;
            TileID.Sets.ForcedDirtMerging[Type] = true;
            DustType = DustID.MothronEgg;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(160, 156, 146));
        }
    }
}
