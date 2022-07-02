using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class MarbleBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/MarbleBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Marble;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(168, 178, 204));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.MarbleBrick>());
            return true;
        }
    }
}
