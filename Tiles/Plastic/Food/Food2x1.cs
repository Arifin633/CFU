using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Food2x1 : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Food/Food2x1";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleMultiplier = 5;
            TileObjectData.newTile.StyleWrapLimit = 5;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bowl of Soup");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("CookedFish");
            name.SetDefault("Cooked Fish");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("CookedShrimp");
            name.SetDefault("Cooked Shrimp");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("PadThai");
            name.SetDefault("Pad Thai");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("Pho");
            name.SetDefault("Pho");
            AddMapEntry(new Color(224, 219, 236), name);
            name = CreateMapEntryName("Sashimi");
            name.SetDefault("Sashimi");
            AddMapEntry(new Color(224, 219, 236), name);

            DustType = -1;
            AnimationFrameHeight = 20;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.BowlOfSoup>(),
                             ModContent.ItemType<Items.CookedFish>(),
                             ModContent.ItemType<Items.CookedShrimp>(),
                             ModContent.ItemType<Items.PadThai>(),
                             ModContent.ItemType<Items.Pho>(),
                             ModContent.ItemType<Items.Sashimi>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[frameX / 36]);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 16)
            {
                frameCounter = 0;
                frame = ++frame % 5;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
            => offsetY = -2;
    }
}
