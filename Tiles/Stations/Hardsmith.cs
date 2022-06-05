using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    class Hardsmith : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Stations/Hardsmith";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 74;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Blacksmith's Forge");
            AddMapEntry(new Color(81, 81, 89), name);
            AdjTiles = new int[] { TileID.Furnaces, TileID.Anvils, 133, 134, 77 };
            AnimationFrameHeight = 56;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            r = 0.7f;
            g = 0.5f;
            b = 0.5f;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameX < 144)
                CFUtils.ForgeDrawSmoke(i, j, spriteBatch, "HardsmithSmokeMythril", 8, 26, Type);
            else CFUtils.ForgeDrawSmoke(i, j, spriteBatch, "HardsmithSmokeOrichalcum", 8, 26, Type);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                frame = ++frame % 5;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
            switch (frameX / 72)
            {
                case 0:
                    item = ModContent.ItemType<Items.HardsmithAdmMyt>();
                    break;
                case 1:
                    item = ModContent.ItemType<Items.HardsmithAdmOri>();
                    break;
                case 2:
                    item = ModContent.ItemType<Items.HardsmithTitMyt>();
                    break;
                case 3:
                    item = ModContent.ItemType<Items.HardsmithTitOri>();
                    break;
            }

            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, item);
        }
    }
}
