using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Mirrors : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Mirrors";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Mirror");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = {
                ModContent.ItemType<Items.MirrorWood>(),
                ModContent.ItemType<Items.MirrorBoreal>(),
                ModContent.ItemType<Items.MirrorPalm>(),
                ModContent.ItemType<Items.MirrorMahogany>(),
                ModContent.ItemType<Items.MirrorEbon>(),
                ModContent.ItemType<Items.MirrorShade>(),
                ModContent.ItemType<Items.MirrorPearl>(),
                ModContent.ItemType<Items.MirrorPrin>(),
            };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 36, 48, styles[(frameX / 36)]);
        }
    }
}
