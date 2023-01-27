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
            Main.tileNoAttach[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 18;
            // TileObjectData.newTile.StyleMultiplier = 18;
            // TileObjectData.newTile.RandomStyleRange = 18;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.OnlyInLiquid;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.EmptyTile, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(26, 196, 84));
            AddMapEntry(new Color(48, 208, 234));
            AddMapEntry(new Color(135, 196, 26));
            AddMapEntry(new Color(203, 61, 64));
            AddMapEntry(new Color(122, 116, 218));
            HitSound = SoundID.Grass;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 18);

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 18)
            {
                case 0:
                    type = DustID.GrassBlades;
                    break;
                case 1:
                    type = DustID.HallowedPlants;
                    break;
                case 2:
                    type = DustID.JunglePlants;
                    break;
                case 3:
                    type = DustID.CrimsonPlants;
                    break;
                case 4:
                    type = DustID.CorruptPlants;
                    break;
            }
            return true;
        }


        public override bool PreDraw(int i, int j, SpriteBatch _) => (Main.tile[i, j].LiquidAmount == 0);

        public override bool Drop(int i, int j)
        {
            int[] styles = { ItemID.GrassSeeds,
                             ItemID.HallowedSeeds,
                             ItemID.JungleGrassSeeds,
                             ItemID.CrimsonSeeds,
                             ItemID.CorruptSeeds};
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(Main.tile[i, j].TileFrameY / 16)]);
            return true;
        }
    }
}
