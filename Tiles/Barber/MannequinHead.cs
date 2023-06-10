using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class MannequinHeadTE : ModTileEntity
    {
        public Player Player = new Player();

        public override bool IsTileValidForEntity(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            return tile.HasTile &&
                (tile.TileType == ModContent.TileType<Tiles.MannequinHead>());
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            var result = Place(i, j);
            var te = (MannequinHeadTE)ByID[result];
            var player = te.Player;

            Vector2 pos = new Vector2(i * 16, j * 16) + new Vector2(6, -(16 + 2));
            player.GetModPlayer<MannequinHeadPlayer>().IsMannequinHead = true;
            player.direction = direction;
            player.Male = true;
            player.isDisplayDollOrInanimate = true;
            player.ResetEffects();
            player.ResetVisibleAccessories();
            player.UpdateDyes();
            player.DisplayDollUpdate();
            player.PlayerFrame();
            player.position = pos;

            return result;
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Set("Position", Player.position);
            tag.Set("Direction", Player.direction);
            tag.Set("HairStyle", Player.hair);
            tag.Set("HairColor", Player.hairColor);
        }
        
        public override void LoadData(TagCompound tag)
        {
            Player.GetModPlayer<MannequinHeadPlayer>().IsMannequinHead = true;
            Player.direction = tag.GetInt("Direction");
            Player.hair = tag.GetInt("HairStyle");
            Player.hairColor = tag.Get<Color>("HairColor");
            Player.Male = true;
            Player.isDisplayDollOrInanimate = true;
            Player.ResetEffects();
            Player.ResetVisibleAccessories();
            Player.UpdateDyes();
            Player.DisplayDollUpdate();
            Player.PlayerFrame();
            Player.position = tag.Get<Vector2>("Position");
        }

        public override void NetPlaceEntityAttempt(int i, int j)
        {
            base.NetPlaceEntityAttempt(i, j);
        }

        public override void OnNetPlace()
        {
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, Position.X, Position.Y);
        }
    }
    
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
        
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<MannequinHeadTE>().Hook_AfterPlacement, -1, 0, false);
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
            {
                Player player = FindPlayer(i, j);
                if (player != null)
                {
                    UI.UISystem.HairState.OpenWindow(player);
                }
            }
            else
            {
                UI.UISystem.HairState.CloseWindow(revert: true);
            }
            return true;
        }

        public static Player FindPlayer(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;
            j = (frameY is 0) ? (j + 1) : j;
            i = (frameX is not (0 or 36)) ? (i - 1): i;

            if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var te))
            {
                MannequinHeadTE mte = (MannequinHeadTE)te;
                return mte.Player;
            }
            else return null;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;
            if (frameX is 0 or 36 && frameY is 18)
            {
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.Player);
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.MannequinHead>());
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            j = (frameY is 0) ? (j + 1) : j;
            i = (frameX is not (0 or 36)) ? (i - 1): i;
            if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var te))
            {
                MannequinHeadTE mte = (MannequinHeadTE)te;
                mte.Kill(i, j);
            }
        }
    }
}
