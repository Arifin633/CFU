using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class Chests : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Chests";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ChestsHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicChest[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ChestDrop = ModContent.ItemType<Items.PrinChest>();

            ModTranslation name = CreateMapEntryName();
            name.SetDefault(Names[0]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("MysticChest");
            name.SetDefault(Names[1]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("RoyalChest");
            name.SetDefault(Names[2]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("SandstoneChest");
            name.SetDefault(Names[3]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Containers };
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public static string MapChestName(string name, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 2));
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);

            if (Main.chest[chest].name is "" or "Princess Chest"
                                             or "Mystical Chest"
                                             or "Royal Chest"
                                             or "Sandstone Urn")
                return name;

            return name + ": " + Main.chest[chest].name;
        }

        public static readonly string[] Names =
            { "Princess Chest", "Mystical Chest", "Royal Chest", "Sandstone Urn" };

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinChest>(),
              ModContent.ItemType<Items.MysticChest>(),
              ModContent.ItemType<Items.RoyalChest>(),
              ModContent.ItemType<Items.AltSandstoneChest>() };

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameX / 36)]);
            Chest.DestroyChest(i, j);
        }

        public override bool RightClick(int i, int j)
        {
            CFUtils.OpenChest(i, j, 2);
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;

            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 2));
            int top = (tile.TileFrameY != 0) ? (j - 1) : j;

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconText = Main.chest[chest].name;
            switch (tile.TileFrameX / 36)
            {
                case 0:
                    if (Main.chest[chest].name is "Princess Chest" or "")
                    {
                        player.cursorItemIconID = Styles[0];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 1:
                    if (Main.chest[chest].name is "Mystical Chest" or "")
                    {
                        player.cursorItemIconID = Styles[1];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 2:
                    if (Main.chest[chest].name is "Royal Chest" or "")
                    {
                        player.cursorItemIconID = Styles[2];
                        player.cursorItemIconText = "";
                    }
                    break;
                case 3:
                    if (Main.chest[chest].name is "Sandstone Urn" or "")
                    {
                        player.cursorItemIconID = Styles[3];
                        player.cursorItemIconText = "";
                    }
                    break;
            }
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }

        /* Although this doesn't work properly, I can't imagine it would look
           very good even if it did.  TODO: Make a proper animation. */
        /* public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX is 36 && tile.TileFrameY is 0) //  tile.TileFrameY is 38 or 76
            {
                ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                for (int k = 0; k < 7; k++)
                {
                    float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                    spriteBatch.Draw(
                        ModContent.Request<Texture2D>("CFU/Textures/Tiles/Furniture/MysticChestVoid").Value,
                        new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + x, (float)(j * 16 - (int)Main.screenPosition.Y) + y) + zero,
                        new Rectangle(0, 0, 34, 36),
                        Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f
                        );
                }
            }
            return true;
        } */
    }
}
