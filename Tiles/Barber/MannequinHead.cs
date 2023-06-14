using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ChadsFurnitureUpdated;
using System.IO;
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
        bool fixDirection = false;

        public override void Update()
        {
            if (fixDirection)
            {
                int x = (int)((Player.position.X - 6) / 16f);
                int y = (int)((Player.position.Y + 18) / 16f);
                if (Main.tile[x, y].HasTile)
                {
                    fixDirection = false;
                    Player.direction = (Main.tile[x, y].TileFrameX == 0) ? -1 : 1;
                    NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, x, y);
                }
            }
        }

        public override bool IsTileValidForEntity(int i, int j)
        {
            /* This happens BEFORE the tile is placed and is thus rather useless. */
            // Tile tile = Main.tile[i, j];
            // return tile.HasTile &&
            //     (tile.TileType == ModContent.TileType<Tiles.MannequinHead>());
            return true;
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            int result = -1;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type);
            }
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                result = Place(i, j);
                var te = (MannequinHeadTE)ByID[result];
                var player = te.Player;
                Vector2 pos = new Vector2(i * 16, j * 16) + new Vector2(6, -(16 + 2));
                player.GetModPlayer<MannequinHeadPlayer>().IsMannequinHead = true;
                player.direction = (Main.tile[i, j].TileFrameX == 0) ? -1 : 1;
                player.isDisplayDollOrInanimate = true;
                player.position = pos;
            }

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
            Player.isDisplayDollOrInanimate = true;
            Player.position = tag.Get<Vector2>("Position");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteVector2(Player.position);
            writer.Write(Player.direction);
            writer.Write(Player.hair);
            writer.Write(Player.hairColor.R);
            writer.Write(Player.hairColor.G);
            writer.Write(Player.hairColor.B);
        }

        public override void NetReceive(BinaryReader reader)
        {
            var position = reader.ReadVector2();
            var direction = reader.ReadInt32();
            var hair = reader.ReadInt32();
            var r = reader.ReadByte();
            var g = reader.ReadByte();
            var b = reader.ReadByte();

            Player.GetModPlayer<MannequinHeadPlayer>().IsMannequinHead = true;
            Player.direction = direction;
            Player.hair = hair;
            Player.hairColor = new Color(r, g, b);
            Player.isDisplayDollOrInanimate = true;
            Player.position = position;
        }

        public override void NetPlaceEntityAttempt(int i, int j)
        {
            if (!manager.TryGetTileEntity(Type, out ModTileEntity modTileEntity))
            {
                return;
            }

            int id = modTileEntity.Place(i, j);
            var te = (MannequinHeadTE)ByID[id];
            var player = te.Player;

            Vector2 pos = new Vector2(i * 16, j * 16) + new Vector2(6, -(16 + 2));
            player.GetModPlayer<MannequinHeadPlayer>().IsMannequinHead = true;
            // player.direction = (Main.tile[i, j].TileFrameX == 0) ? -1 : 1;
            te.fixDirection = true;
            player.isDisplayDollOrInanimate = true;
            player.position = pos;

            te.OnNetPlace();
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, id, i, j);
        }

        /* Sent by the client to effectualize the changes made to the server. */
        public static void SendPacket(Player player)
        {
            int x = (int)((player.position.X - 6) / 16f);
            int y = (int)((player.position.Y + 18) / 16f);
            if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out var te))
            {
                var mte = (Tiles.MannequinHeadTE)te;
                ModPacket packet = ModContent.GetInstance<ChadsFurnitureUpdated.CFU>().GetPacket();
                packet.WriteVector2(mte.Player.position);
                packet.Write(mte.Player.hair);
                packet.Write(mte.Player.hairColor.R);
                packet.Write(mte.Player.hairColor.G);
                packet.Write(mte.Player.hairColor.B);
                packet.Send();
            }
        }

        /* Automatically handled in `CFU.HandlePackets'. */
        public static void ReceivePacket(BinaryReader reader)
        {
            var position = reader.ReadVector2();
            var hair = reader.ReadInt32();
            var r = reader.ReadByte();
            var g = reader.ReadByte();
            var b = reader.ReadByte();

            int x = (int)((position.X - 6) / 16f);
            int y = (int)((position.Y + 18) / 16f);
            if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out var te))
            {
                var mte = (Tiles.MannequinHeadTE)te;
                mte.Player.hair = hair;
                mte.Player.hairColor = new Color(r, g, b);
                NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, te.ID, x, y);
            }
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
            i = (frameX is not (0 or 36)) ? (i - 1) : i;

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

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = ModContent.ItemType<Items.MannequinHead>();
            player.cursorItemIconReversed = !(Main.tile[i, j].TileFrameX is 0 or 18);
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.MannequinHead>());
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            j = (frameY is 0) ? (j + 1) : j;
            i = (frameX is not (0 or 36)) ? (i - 1) : i;
            if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var te))
            {
                MannequinHeadTE mte = (MannequinHeadTE)te;
                mte.Kill(i, j);
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, te.ID, i, j);
            }
        }
    }
}
