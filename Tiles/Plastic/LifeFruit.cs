using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class LifeFruit : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/LifeFruit";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Life Fruit");
            AddMapEntry(new Color(219, 157, 64), name);
            DustType = 1;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (((Main.tile[i, j].TileFrameX % 36) == 0) &&
                (Main.tile[i, j].TileFrameY == 0))
            {
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.LifeFruit>());
        }
    }
}
