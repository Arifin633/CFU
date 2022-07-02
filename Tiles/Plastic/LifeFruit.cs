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
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Life Fruit");
            AddMapEntry(new Color(149, 232, 87), name);
            DustType = DustID.JunglePlants;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if (!CFUConfig.WindEnabled())
            {
                int potType = ModContent.TileType<Tiles.PlantPots>();
                if ((Main.tile[i, j + 1].TileType == potType) ||
                     ((Main.tile[i, j + 1].TileType == Type) &&
                      (Main.tile[i, j + 2].TileType == potType)))
                    offsetY = -4;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                ((Main.tile[i, j].TileFrameX % 36) == 0) &&
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
