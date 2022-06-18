using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Eggnog : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/Food/Eggnog";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.CoordinateWidth = 18;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Eggnog");
            AddMapEntry(new Color(133, 213, 247), name);
            DustType = 1;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Eggnog>());
            return true;
        }


        // public override bool PreDraw(int i, int j, SpriteBatch spriteBatch){
        // 	Tile tile = Main.tile[i, j];
        // 	Texture2D texture;
        // 	if (Main.canDrawColorTile(i, j))
        // 	{
        // 		texture = Main.tileAltTexture[Type, (int)tile.color()];
        // 	}
        // 	else
        // 	{
        // 		texture = Main.tileTexture[Type];
        // 	}
        // 	Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        // 	if (Main.drawToScreen)
        // 	{
        // 		zero = Vector2.Zero;
        // 	}
        // 	Main.spriteBatch.Draw(
        // 		texture,
        // 		new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
        // 		new Rectangle(tile.TileFrameX, tile.TileFrameY, 18, 18),
        // 		Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
        // 	return false;
        // }
    }
}
