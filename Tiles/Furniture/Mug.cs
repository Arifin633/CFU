using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Mug : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Mug";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Mug");
            AddMapEntry(new Color(204, 204, 204), name);
            DustType = -1;
            HitSound = SoundID.Shatter;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.PaintableMug>());
            return true;
        }
    }
}
