using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Banners : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Teams/Banners";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 18;
            TileObjectData.addTile(Type);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            AddMapEntry(new Color(117, 20, 11), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.RedBanner>(),
                             ModContent.ItemType<Items.GreenBanner>(),
                             ModContent.ItemType<Items.BlueBanner>(),
                             ModContent.ItemType<Items.YellowBanner>(),
                             ModContent.ItemType<Items.PinkBanner>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, styles[(frameX / 18)]);
        }
    }
}
