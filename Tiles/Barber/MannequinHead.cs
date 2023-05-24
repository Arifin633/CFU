using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MannequinHeadPlayer : ModPlayer
    {
        public bool IsMannequinHead = false;

        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            if (IsMannequinHead)
            {
                drawInfo.colorEyeWhites = Color.Transparent;
                drawInfo.colorEyes = Color.Transparent;
                drawInfo.colorHead = Color.Transparent;
                drawInfo.colorBodySkin = Color.Transparent;
                drawInfo.colorLegs = Color.Transparent;
                drawInfo.colorShirt = Color.Transparent;
                drawInfo.colorUnderShirt = Color.Transparent;
                drawInfo.colorPants = Color.Transparent;
                drawInfo.colorShoes = Color.Transparent;
            }
        }
    }

    public class MannequinHead : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Barber/MannequinHead";

        public static Player Player = new Player();
        
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(191, 142, 111));
            DustType = DustID.WoodFurniture;
        }

        public override bool RightClick(int i, int j)
        {
            if (UI.UISystem.HairInterface?.CurrentState == null)
                UI.UISystem.HairState.OpenWindow(Player);
            else
                UI.UISystem.HairState.CloseWindow(revert: true);
            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) // This all goes into the after placement hook
        {
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;
            if (frameX is 0 or 36 && frameY is 0)
            {
                Vector2 pos = new Vector2(i * 16, j * 16) + new Vector2(6, -2);
                var mp = Player.GetModPlayer<MannequinHeadPlayer>();
                mp.IsMannequinHead = true;
                Player.direction = (frameX == 36) ? 1 : -1;
                Player.Male = true;
                Player.isDisplayDollOrInanimate = true;
                Player.ResetEffects();
                Player.ResetVisibleAccessories();
                Player.UpdateDyes();
                Player.DisplayDollUpdate();
                Player.PlayerFrame();
                Player.position = pos;
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.Player);
            }
        }
    }
}
