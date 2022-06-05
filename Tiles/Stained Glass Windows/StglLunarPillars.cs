using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class StglLunarPillars : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Stained Glass Windows/StglLunarPillars";

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Stained Glass Window");
            AddMapEntry(new Color(133, 213, 247), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.StglNebula>(),
                             ModContent.ItemType<Items.StglSolar>(),
                             ModContent.ItemType<Items.StglStardust>(),
                             ModContent.ItemType<Items.StglVortex>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameY / 72)]);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX < 36)
            {
                switch (tile.TileFrameY)
                {
                    case < 72:  /* Nebula */
                    case < 144: /* Solar*/
                        r = 0.6f;
                        g = 0.3f;
                        b = 0.2f;
                        break;
                    case < 216: /* Stardust */
                        r = 0.4f;
                        g = 0.2f;
                        b = 0.5f;
                        break;
                    default:    /* Vortex */
                        r = 0.5f;
                        g = 0.3f;
                        b = 0.3f;
                        break;
                }
            }
            else
            {
                r = 0f;
                g = 0f;
                b = 0f;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if ((tile.TileFrameX < 36) && !Main.dayTime)
            {
                tile.TileFrameX += 36;
            }
            else if ((tile.TileFrameX >= 36) && Main.dayTime)
            {
                tile.TileFrameX -= 36;
            }
        }
    }
}
