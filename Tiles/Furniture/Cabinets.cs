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
    public class Cabinets : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Cabinets";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/CabinetsHighlight";
        
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
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            ModTranslation name = CreateMapEntryName();
            foreach (string styleName in Names)
            {
                name = CreateMapEntryName(styleName.Replace(" ", ""));
                name.SetDefault(styleName);
                AddMapEntry(new Color(181, 172, 190), name, MapChestName);
            }
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Dressers };
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameX / 36);

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        // public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        // {
        //     width = 2;
        //     height = 1;
        // }

        public static string MapChestName(string name, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = ((tile.TileFrameX % 36) == 0) ? i : (i - 1);
            int top = (tile.TileFrameY == 0) ? j : (j - 1);

            int chest = Chest.FindChest(left, top);

            if (System.Array.Exists
                (Names, name => name == Main.chest[chest].name) ||
                Main.chest[chest].name == "")
                return name;

            return name + ": " + Main.chest[chest].name;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameY == 0)
            {
                CFUtils.OpenChest(i, j, 2);
            }
            else
            {
                Main.playerInventory = false;
                player.chest = -1;
                Recipe.FindRecipes();
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = "";
                Main.interactedDresserTopLeftX = (((tile.TileFrameX % 36) == 0) ? i : (i - 1));
                Main.interactedDresserTopLeftY = j - 1;
                Main.OpenClothesWindow();
            }

            return true;
        }

        public static readonly string[] Names =
            { "Cabinet",
              "Boreal Wood Cabinet",
              "Palm Wood Cabinet",
              "Rich Mahogany Cabinet",
              "Ebonwood Cabinet",
              "Shadewood Cabinet",
              "Pearlwood Cabinet",
              "Spooky Cabinet",
              "Cactus Cabinet",
              "Pumpkin Cabinet",
              "Mushroom Cabinet",
              "Glass Cabinet",
              "Steampunk Cabinet",
              "Skyware Cabinet",
              "Honey Cabinet",
              "Slime Cabinet",
              "Meteorite Cabinet",
              "Granite Cabinet",
              "Marble Cabinet",
              "Bone Cabinet",
              "Flesh Cabinet",
              "Lihzarhd Cabinet",
              "Obsidian Cabinet",
              "Golden Cabinet",
              "Martian Cabinet",
              "Blue Dungeon Cabinet",
              "Green Dungeon Cabinet",
              "Pink Dungeon Cabinet",
              "Crystal Cabinet",
              "Dynasty Cabinet",
              "Frozen Cabinet",
              "Living Wood Cabinet" };

        static readonly int[] Styles =
            { ModContent.ItemType<Items.CabinetWood>(),
              ModContent.ItemType<Items.CabinetBoreal>(),
              ModContent.ItemType<Items.CabinetPalm>(),
              ModContent.ItemType<Items.CabinetMahogany>(),
              ModContent.ItemType<Items.CabinetEbon>(),
              ModContent.ItemType<Items.CabinetShade>(),
              ModContent.ItemType<Items.CabinetPearl>(),
              ModContent.ItemType<Items.CabinetSpooky>(),
              ModContent.ItemType<Items.CabinetCactus>(),
              ModContent.ItemType<Items.CabinetPumpkin>(),
              ModContent.ItemType<Items.CabinetMushroom>(),
              ModContent.ItemType<Items.CabinetGlass>(),
              ModContent.ItemType<Items.CabinetSteampunk>(),
              ModContent.ItemType<Items.CabinetSkyware>(),
              ModContent.ItemType<Items.CabinetHoney>(),
              ModContent.ItemType<Items.CabinetSlime>(),
              ModContent.ItemType<Items.CabinetMeteor>(),
              ModContent.ItemType<Items.CabinetGranite>(),
              ModContent.ItemType<Items.CabinetMarble>(),
              ModContent.ItemType<Items.CabinetBone>(),
              ModContent.ItemType<Items.CabinetFlesh>(),
              ModContent.ItemType<Items.CabinetLizard>(),
              ModContent.ItemType<Items.CabinetObsidian>(),
              ModContent.ItemType<Items.CabinetGolden>(),
              ModContent.ItemType<Items.CabinetMartian>(),
              ModContent.ItemType<Items.CabinetBlue>(),
              ModContent.ItemType<Items.CabinetGreen>(),
              ModContent.ItemType<Items.CabinetPink>(),
              ModContent.ItemType<Items.CabinetCrystal>(),
              ModContent.ItemType<Items.CabinetDynasty>(),
              ModContent.ItemType<Items.CabinetFrozen>(),
              ModContent.ItemType<Items.CabinetLiving>() };

        public override void MouseOver(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;

            if (tile.TileFrameY == 0)
            {
                int chest = Chest.FindChest((((tile.TileFrameX % 36) == 0) ? i : (i - 1)), j);
                int style = tile.TileFrameX / 36;
                if (Main.chest[chest].name == Names[style] ||
                    Main.chest[chest].name == "")
                {
                    player.cursorItemIconID = Styles[style];
                    player.cursorItemIconText = "";
                }
                else player.cursorItemIconText = Main.chest[chest].name;
            }
            else player.cursorItemIconID = ItemID.FamiliarShirt;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, Styles[(frameX / 36)]);
            Chest.DestroyChest(i, j);
        }
    }
}
