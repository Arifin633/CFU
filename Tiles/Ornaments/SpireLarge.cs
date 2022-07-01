using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class SpireLarge : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ornaments/SpireLarge";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.Origin = new Point16(0, 4);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Spire");
            AddMapEntry(new Color(160, 156, 146), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 92)
            {
                case 0:
                case 2:
                    type = DustID.MothronEgg;
                    break;
                case 1:
                case 3:
                    type = DustID.Stone;
                    break;
            }
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.LimestoneSpireLarge>(),
                             ModContent.ItemType<Items.StoneSpireLarge>(),
                             ModContent.ItemType<Items.LimestonePinnacle>(),
                             ModContent.ItemType<Items.StonePinnacle>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 92)]);
        }
    }
}
