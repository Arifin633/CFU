using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CFU.Tiles
{
    public class OrganPipe : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Blocks/OrganPipe";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            DustType = 0;
            AddMapEntry(new Color(81, 81, 89));
        }

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.OrganPipe>());
            return true;
        }

        // public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        // {
        // 	if((Main.tile[i,j-1].type != 0) && (Main.tile[i,j+1].type == Main.tile[i,j].type) && (Main.tile[i,j-1].type != Main.tile[i,j].type))
        // 	{
        // 		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        // 		if (Main.drawToScreen)
        // 		{
        // 			zero = Vector2.Zero;
        // 		}
        // 		
        // 		Main.spriteBatch.Draw(mod.GetTexture("Tiles/Blocks/OrganPipe"), new Vector2(i * 16 - (int)Main.screenPosition.X,
        // 		j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
        // 		new Rectangle(0, 0, 16, 16),
        // 		Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // 		Main.spriteBatch.Draw(mod.GetTexture("Tiles/Blocks/OrganPipe"), new Vector2(i * 16 - (int)Main.screenPosition.X,
        // 		j * 16 - (int)Main.screenPosition.Y) + zero,
        // 		new Rectangle(0, 0, 16, 16),
        // 		Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // 		return false;
        // 	}
        // 	else return true;
        // }
    }
}
