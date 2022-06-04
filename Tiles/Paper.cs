using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Paper : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Paper";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16
            };
            //	TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            //	TileObjectData.newTile.AnchorAlternateTiles = new int[]{ mod.TileType("Paper") };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Paper Stack");
            AddMapEntry(new Color(197, 183, 166), name);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.Paper>());
            return true;
        }
    }
}
