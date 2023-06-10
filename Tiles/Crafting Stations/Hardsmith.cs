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
        public override string Texture => "CFU/Textures/Tiles/Crafting Stations/Hardsmith";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.Furnaces, TileID.Anvils, TileID.AdamantiteForge, TileID.MythrilAnvil, TileID.Hellforge };
            AddMapEntry(new Color(231, 53, 56));
            AddMapEntry(new Color(192, 189, 221));
            AnimationFrameHeight = 56;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)((Main.tile[i, j].TileFrameX / 72) % 2);

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
                CFUTileDraw.ForgeDrawSmoke(i, j, spriteBatch, "HardsmithSmokeMythril", 8, 26, Type);
            else CFUTileDraw.ForgeDrawSmoke(i, j, spriteBatch, "HardsmithSmokeOrichalcum", 8, 26, Type);
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                frame = ++frame % 5;
            }
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            int dust1 = 0;
            int dust2 = 0;
            switch (Main.tile[i, j].TileFrameX / 72)
            {
                case 0:
                    dust1 = DustID.Adamantite;
                    dust2 = DustID.Mythril;
                    break;
                case 1:
                    dust1 = DustID.Titanium;
                    dust2 = DustID.Mythril;
                    break;
                case 2:
                    dust1 = DustID.Adamantite;
                    dust2 = DustID.Orichalcum;
                    break;
                case 3:
                    dust1 = DustID.Titanium;
                    dust2 = DustID.Orichalcum;
                    break;
            }
            type = (Main.rand.NextBool(2)) ? dust2 : dust1;
            return true;
        }
    }
}
