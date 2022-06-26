using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class ShadowOrbCrimsonHeart : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/ShadowOrbCrimsonHeart";

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(98, 75, 107));
            AnimationFrameHeight = 36;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 11)
            {
                frameCounter = 0;
                frame = ++frame % 2;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float rand = Main.rand.Next(-5, 6) * 0.0025f;
            if (Main.tile[i, j].TileFrameX >= 36)
            {
                r = 0.5f + rand * 2f;
                g = 0.2f + rand;
                b = 0.1f;
            }
            else
            {
                r = 0.31f + rand;
                g = 0.1f;
                b = 0.44f + rand * 2f;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.ShadowOrb>(),
                             ModContent.ItemType<Items.CrimsonHeart>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameX / 36)]);
        }
    }
}
