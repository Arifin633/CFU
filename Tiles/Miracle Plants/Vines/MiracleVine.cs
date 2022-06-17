using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MiracleVine : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/Vines/MiracleVine";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;

            DustType = 0;
            AddMapEntry(new Color(14, 152, 64));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.MiracleVine>());
            return true;
        }

        public override bool CanPlace(int i, int j)
        {
            var topTile = Main.tile[i, j - 1];
            return (topTile.HasTile &&
                    (Main.tileSolid[topTile.TileType] || topTile.TileType == Type));
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            fail = effectOnly = noItem = false;
            if (Main.tile[i, (j + 1)].TileType == Type)
                WorldGen.KillTile(i, (j + 1));
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => false;

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if (Main.tile[i, j - 1].TileType != Type)
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingVine);
        }
    }
}
