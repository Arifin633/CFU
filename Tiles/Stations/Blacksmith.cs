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
    class Blacksmith : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Stations/Blacksmith";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
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
            AdjTiles = new int[] { TileID.Furnaces, TileID.Anvils };
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
            CFUTileDraw.ForgeDrawSmoke(i, j, spriteBatch, "BlacksmithSmoke", 32, 26, Type);
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
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Blacksmith>());
        }
    }
}
