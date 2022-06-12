using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Dressers : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Dressers";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/DressersHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileContainer[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicDresser[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault(Names[0]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("MysticDresser");
            name.SetDefault(Names[1]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("RoyalDresser");
            name.SetDefault(Names[2]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            name = CreateMapEntryName("SandstoneDresser");
            name.SetDefault(Names[3]);
            AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Dressers };
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 36);

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            width = 2;
            height = 2;
        }

        public static string MapChestName(string name, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = (i - ((tile.TileFrameX / 18) % 3));
            int top = (tile.TileFrameY % 38 == 0) ? j : (j - 1);

            int chest = Chest.FindChest(left, top);

            if (Main.chest[chest].name is "" or "Princess Dresser"
                                             or "Mystical Dresser"
                                             or "Royal Dresser"
                                             or "Sandstone Dresser")
                return name;

            return name + ": " + Main.chest[chest].name;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameY % 38 == 0)
            {
                CFUtils.OpenChest(i, j, 3);
            }
            else
            {
                Main.playerInventory = false;
                player.chest = -1;
                Recipe.FindRecipes();
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = "";
                Main.interactedDresserTopLeftX = (i - tile.TileFrameX / 18);
                Main.interactedDresserTopLeftY = (j - 1);
                Main.OpenClothesWindow();
            }

            return true;
        }

        public static readonly string[] Names =
            { "Princess Dresser", "Mystical Dresser", "Royal Dresser" ,"Sandstone Dresser" };

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinDresser>(),
              ModContent.ItemType<Items.MysticDresser>(),
              ModContent.ItemType<Items.RoyalDresser>(),
              ModContent.ItemType<Items.AltSandstoneDresser>() };


        public override void MouseOver(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;

            if (tile.TileFrameY % 38 == 0)
            {
                int chest = Chest.FindChest((i - tile.TileFrameX / 18), j);
                player.cursorItemIconText = Main.chest[chest].name;
                switch (tile.TileFrameY / 36)
                {
                    case 0:
                        if (Main.chest[chest].name is "Princess Dresser" or "")
                        {
                            player.cursorItemIconID = Styles[0];
                            player.cursorItemIconText = "";
                        }
                        break;
                    case 1:
                        if (Main.chest[chest].name is "Mystical Dresser" or "")
                        {
                            player.cursorItemIconID = Styles[1];
                            player.cursorItemIconText = "";
                        }
                        break;
                    case 2:
                        if (Main.chest[chest].name is "Royal Dresser" or "")
                        {
                            player.cursorItemIconID = Styles[2];
                            player.cursorItemIconText = "";
                        }
                        break;
                    case 3:
                        if (Main.chest[chest].name is "Sandstone Dresser" or "")
                        {
                            player.cursorItemIconID = Styles[3];
                            player.cursorItemIconText = "";
                        }
                        break;
                }
            }
            else player.cursorItemIconID = ItemID.FamiliarShirt;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, Styles[(frameY / 36)]);
            Chest.DestroyChest(i, j);
        }
    }
}
