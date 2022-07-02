using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class LeadGlass : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/LeadGlass";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            DustType = DustID.Glass;
            HitSound = SoundID.Shatter;
            AddMapEntry(new Color(133, 213, 247));
        }
        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.LeadGlass>());
            return true;
        }
    }

}
