using Microsoft.Xna.Framework;
using System.Collections.Generic;
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
            TileID.Sets.DisableSmartCursor[Type] = true;
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
            AddMapEntry(new Color(160, 156, 146));
            AddMapEntry(new Color(128, 128, 128));
        }

        public override ushort GetMapOption(int i, int j) => (ushort)((Main.tile[i, j].TileFrameY / 92) % 2);

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

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.LimestoneSpireLarge>(),
                             ModContent.ItemType<Items.StoneSpireLarge>(),
                             ModContent.ItemType<Items.LimestonePinnacle>(),
                             ModContent.ItemType<Items.StonePinnacle>() };
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 92)]);
        }
    }
}
