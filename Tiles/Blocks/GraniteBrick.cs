using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class GraniteBrick : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/GraniteBrick";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            ChadsFurnitureUpdated.CFUtils.SetupTileMerge(Type);
            Main.tileBlockLight[Type] = true;
            DustType = DustID.Granite;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(50, 46, 104));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.GraniteBrick>());
            return true;
        }
    }
}
