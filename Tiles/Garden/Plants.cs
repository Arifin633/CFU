using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Plants : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Garden/Plants";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Plants");
            AddMapEntry(new Color(14, 152, 64), name);
            DustType = -1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (Main.tile[i, j].TileFrameX >= 228 &&
                Main.tile[i, j].TileFrameX < 342)
            {
                SoundEngine.PlaySound(SoundID.Dig, new Vector2(i * 16, j * 16));
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Grass, new Vector2(i * 16, j * 16));
            }
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
            int[] styles = { ModContent.ItemType<Items.Plant0>(),
                             ModContent.ItemType<Items.Plant1>(),
                             ModContent.ItemType<Items.Plant2>(),
                             ModContent.ItemType<Items.Plant3>(),
                             ModContent.ItemType<Items.Plant4>(),
                             ModContent.ItemType<Items.Plant5>(),
                             ModContent.ItemType<Items.Plant6>(),
                             ModContent.ItemType<Items.Plant7>(),
                             ModContent.ItemType<Items.Plant8>(),
                             ModContent.ItemType<Items.Plant9>(),
                             ModContent.ItemType<Items.Plant10>(),
                             ModContent.ItemType<Items.Plant11>(),
                             ModContent.ItemType<Items.Plant12>(),
                             ModContent.ItemType<Items.Plant13>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 38)]);
        }
    }
}
