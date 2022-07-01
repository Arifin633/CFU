using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class PlantPots : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Garden/PlantPots";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 22 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pot");
            AddMapEntry(new Color(146, 81, 68), name);
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short _1, ref short _2)
        {
            offsetY = -4;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = {
                ModContent.ItemType<Items.PlantPotWhiteRed>(),
                ModContent.ItemType<Items.PlantPotOrange>(),
                ModContent.ItemType<Items.PlantPotWhite>(),
                ModContent.ItemType<Items.PlantPotPurple>(),
                ModContent.ItemType<Items.PlantPotBrown>(),
                ModContent.ItemType<Items.PlantPotWhiteBlue>(),
                ModContent.ItemType<Items.PlantPotBlackGold>(),
                ModContent.ItemType<Items.PlantPotDarkBrown>(),
                ModContent.ItemType<Items.PlantPotBasket>(),
                ModContent.ItemType<Items.PlantPotTerracotta>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, styles[(frameX / 36)]);
        }
    }
}
