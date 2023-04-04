using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Mug : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Mug";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(204, 204, 204));
            DustType = -1;
            HitSound = SoundID.Shatter;
        }
    }
}
