using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Tables : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Tables";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AdjTiles = new int[] { TileID.Tables };
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Table");
            AddMapEntry(new Color(191, 142, 111), name);
            DustType = -1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.PrinTable>(),
                             ModContent.ItemType<Items.MysticTable>(),
                             0, /* ModContent.ItemType<Items.RoyalTable>(), */
                             ModContent.ItemType<Items.AltSandstoneTable>(),
                             ModContent.ItemType<Items.RushTable>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameX / 54)]);
        }
    }
}
