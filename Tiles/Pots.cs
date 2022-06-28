using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Pots : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Pots";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 3;
            TileObjectData.newTile.RandomStyleRange = 12;
            for (int i = 12; i <= ((9 * 10) + 12); i += 9)
            {
                TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
                TileObjectData.newSubTile.RandomStyleRange = 9;
                TileObjectData.addSubTile(i);
            }
            TileObjectData.addTile(Type);
            // SoundType = 13;
            // SoundStyle = 0;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pot");
            AddMapEntry(new Color(111, 71, 61), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.ForestPot>(),
                             ModContent.ItemType<Items.TundraPot>(),
                             ModContent.ItemType<Items.JunglePot>(),
                             ModContent.ItemType<Items.DungeonPot>(),
                             ModContent.ItemType<Items.UnderworldPot>(),
                             ModContent.ItemType<Items.CorruptionPot>(),
                             ModContent.ItemType<Items.SpiderCavePot>(),
                             ModContent.ItemType<Items.CrimsonPot>(),
                             ModContent.ItemType<Items.PyramidPot>(),
                             ModContent.ItemType<Items.LihzahrdPot>(),
                             ModContent.ItemType<Items.MarbleCavePot>(),
                             ModContent.ItemType<Items.UndergroundDesertPot>() };
            frameY = (frameY <= 36) ? frameY : (frameY - 36);
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 108)]);
        }
    }
}
