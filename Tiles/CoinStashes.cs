using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class CoinStashes : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/CoinStashes";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 6;
            TileObjectData.newTile.StyleMultiplier = 6;
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.addTile(Type);
            // SoundType = 18;
            // SoundStyle = 0;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Coin Stash");
            AddMapEntry(new Color(107, 81, 65), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.CoinStashCopper>(),
                             ModContent.ItemType<Items.CoinStashSilver>(),
                             ModContent.ItemType<Items.CoinStashGold>(),
                             ModContent.ItemType<Items.CoinStashPlatinum>()};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameY / 38)]);
        }
    }
}
