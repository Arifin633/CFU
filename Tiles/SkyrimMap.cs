using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class SkyrimMap : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/SkyrimMap";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 4;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(204, 185, 153));
            DustType = -1;
            HitSound = SoundID.Grass;
        }
    }
}
