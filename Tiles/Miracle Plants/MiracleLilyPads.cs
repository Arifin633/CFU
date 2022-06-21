using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleLilyPads : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleLilyPads";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            // Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 18;
            TileObjectData.newTile.StyleMultiplier = 18;
            TileObjectData.newTile.RandomStyleRange = 18;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.OnlyInLiquid;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(25, 195, 85));
            DustType = 0;
            TileID.Sets.DrawsWalls[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool PreDraw(int i, int j, SpriteBatch _) => (Main.tile[i, j].LiquidAmount == 0);

        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleLilyPad>(),
                             ModContent.ItemType<Items.MiracleHallowedLilyPad>(),
                             ModContent.ItemType<Items.MiracleJungleLilyPad>(),
                             ModContent.ItemType<Items.MiracleCrimsonLilyPad>(),
                             ModContent.ItemType<Items.MiracleCorruptLilyPad>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 16)]);
            return true;
        }
    }
}
