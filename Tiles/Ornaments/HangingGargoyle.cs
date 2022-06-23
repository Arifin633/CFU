using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class HangingGargoyle : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Ornaments/HangingGargoyle";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;
            Main.tileWaterDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Height, 0);
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);


            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Gargoyle");
            AddMapEntry(new Color(160, 156, 146), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.LimestoneHangingGargoyle>(),
                             ModContent.ItemType<Items.StoneHangingGargoyle>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameX / 72)]);
        }

        // public override void MouseOver(int i, int j)
        // {
        // 	Player player = Main.LocalPlayer;
        // 	Tile tile = Main.tile[i, j];
        // 	player.showItemIcon2 = 909;
        // 	player.showItemIconText = "";
        // 	player.noThrow = 2;
        // 	player.showItemIcon = true;
        // }
        // 
        // public override void RightClick(int i, int j)
        // {
        // 	Tile tile = Main.tile[i, j];
        // 	int left = (tile.TileFrameX % 36) == 0 ? i : i-1;
        // 	int top = j - (tile.TileFrameY/18);
        // 	
        // 	if(handleother.turnedOn2D[left,top])
        // 	{
        // 		handleother.turnedOn2D[left,top] = false;
        // 	}
        // 	else
        // 	{
        // 		handleother.turnedOn2D[left,top] = true;
        // 	}
        // }

        // public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        // {
        // 	Tile tile = Main.tile[i, j];
        // 	
        // 	int ver = tile.TileFrameX == 36 ? 48 : 0;
        // 	int ver2 = tile.TileFrameX == 36 ? 0 : 16;
        // 	int left = (tile.TileFrameX % 36) == 0 ? i : i-1;
        // 	int top = j - (tile.TileFrameY/18);
        // 	
        // 	bool water = false;
        // 	
        // 	if(left < 8400 && top < 2400)
        // 	{
        // 		if(handleother.turnedOn2D[left, top]) water = true;
        // 	}
        // 	
        // 	if(Main.raining) water = true;
        // 	
        // 	if((i == left && j == top) && water)
        // 	{
        // 		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
        // 		if (Main.drawToScreen)
        // 		{
        // 			zero = Vector2.Zero;
        // 		}
        // 		Main.spriteBatch.Draw(mod.GetTexture("Tiles/Limestone/GargoyleHanging_water"), new Vector2(i * 16 + ver2 - (int)Main.screenPosition.X,
        // 		j * 16 - (int)Main.screenPosition.Y) + zero,
        // 		new Rectangle(handleother.gargoanim*16, ver, 16, 48),
        // 		Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // 	}
        // }
    }
}
