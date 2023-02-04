using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class StrangePlants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Garden/StrangePlants";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(113, 45, 133));
            AddMapEntry(new Color(235, 137, 2));
            AddMapEntry(new Color(41, 152, 135));
            AddMapEntry(new Color(198, 19, 78));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 38);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 38)
            {
                case 0:
                    type = DustID.CorruptPlants;
                    break;
                case 1:
                    type = DustID.Torch;
                    break;
                case 2:
                    type = DustID.GrassBlades;
                    break;
                case 3:
                    type = DustID.Bone;
                    break;
            }
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short _1, ref short _2)
        {
            int type = ModContent.TileType<Tiles.PlantPots>();
            if (Main.tile[i, j + 1].TileType == type ||
                Main.tile[i, j + 2].TileType == type)
                offsetY = -4;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.StrangePlantPurple>(),
                             ModContent.ItemType<Items.StrangePlantOrange>(),
                             ModContent.ItemType<Items.StrangePlantGreen>(),
                             ModContent.ItemType<Items.StrangePlantRed>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 38)]);
        }
    }
}
