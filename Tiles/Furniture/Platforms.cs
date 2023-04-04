using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Platforms : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Platforms";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.Platforms[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 27;
            TileObjectData.newTile.StyleWrapLimit = 27;
            TileObjectData.newTile.UsesCustomCanPlace = false;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Platforms };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AddMapEntry(new Color(191, 142, 111));
            DustType = -1;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.PrinPlatform>(),
                             ModContent.ItemType<Items.MysticPlatform>(),
                             ModContent.ItemType<Items.RoyalPlatform>(),
                             ModContent.ItemType<Items.SandstonePlatform>()};
            yield return new Item(styles[(Main.tile[i, j].TileFrameY / 18)]);
        }
    }
}
