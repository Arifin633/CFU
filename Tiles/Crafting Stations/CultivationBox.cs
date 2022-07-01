using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class CultivationBox : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/CultivationBox";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cultivation Box");
            HitSound = SoundID.Shatter;
            DustType = -1;
            AddMapEntry(new Color(133, 213, 247), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.CultivationBox>());
        }
    }
}
