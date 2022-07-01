using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class PotionHolder : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/PotionHolder";

        static readonly int[] Potions = {
            -1,   // Empty
            28,   // Lesser Healing Potion
            110,  // Lesser Mana Potion
            126,  // Bottled Water
            188,  // Healing Potion
            189,  // Mana Potion
            226,  // Lesser Restoration Potion
            227,  // Restoration Potion
            288,  // Obsidian Skin Potion
            289,  // Regeneration Potion
            290,  // Swiftness Potion
            291,  // Gills Potion
            292,  // Ironskin Potion
            293,  // Mana Regeneration Potion
            294,  // Magic Power Potion
            295,  // Featherfall Potion
            296,  // Spelunker Potion
            297,  // Invisibility Potion
            298,  // Shine Potion
            299,  // Night Owl Potion
            300,  // Battle Potion
            301,  // Thorns Potion
            302,  // Water Walking Potion
            303,  // Archery Potion
            304,  // Hunter Potion
            305,  // Gravitation Potion
            499,  // Greater Healing Potion
            500,  // Greater Mana Potion
            678,  // Red Potion
            1134, // Bottled Honey
            1340, // Flask of Venom
            1353, // Flask of Cursed Flames
            1354, // Flask of Fire
            1355, // Flask of Gold
            1356, // Flask of Ichor
            1357, // Flask of Nanites
            1358, // Flask of Party
            1359, // Flask of Poison
            2209, // Super Mana Potion
            2322, // Mining Potion
            2323, // Heartreach Potion
            2324, // Calming Potion
            2325, // Builder Potion
            2326, // Titan Potion
            2327, // Flipper Potion
            2328, // Summoning Potion
            2329, // Dangersense Potion
            2344, // Ammo Reservation Potion
            2345, // Lifeforce Potion
            2346, // Endurance Potion
            2347, // Rage Potion
            2348, // Inferno Potion
            2349, // Wrath Potion
            2350, // Recall Potion
            2351, // Teleportation Potion
            2352, // Love Potion
            2353, // Stink Potion
            2354, // Fishing Potion
            2355, // Sonar Potion
            2356, // Crate Potion
            2359, // Warmth Potion
            2756, // Gender Change Potion
            2997, // Wormhole Potion
            3001, // Strange Brew
            3544, // Super Healing Potion
            4477, // Lesser Luck Potion
            4478, // Luck Potion
            4479, // Greater Luck Potion
            4870, // Potion of Return
        };

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 22 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Potion Holder");
            AddMapEntry(new Color(155, 183, 193), name);
            DustType = -1;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            int frameX = Main.tile[i, j].TileFrameX;
            if (frameX > 0)
                player.cursorItemIconID = Potions[(frameX / 18)];
            player.cursorItemIconText = "";
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int frameX = tile.TileFrameX;
            bool client = (Main.netMode == NetmodeID.MultiplayerClient);
            bool update = false;

            if (frameX > 0)
            {
                int item = Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, Potions[(frameX / 18)]);
                if (client)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item);
                }

                tile.TileFrameX = 0;
                update = true;
            }

            int index = System.Array.IndexOf(Potions, player.inventory[player.selectedItem].type);
            if (index != -1)
            {
                tile.TileFrameX = (short)(index * 18);

                Main.mouseItem.stack--;
                player.inventory[player.selectedItem].stack--;
                if (player.inventory[player.selectedItem].stack <= 0)
                {
                    player.inventory[player.selectedItem].SetDefaults();
                    Main.mouseItem.SetDefaults();
                }
                update = true;
            }

            if (update && client)
            {
                NetMessage.SendTileSquare(-1, i, j);
            }

            player.releaseUseItem = false;
            player.mouseInterface = true;
            return true;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            if (tileFrameX > 0) offsetY -= 6;
        }

        public override bool Drop(int i, int j)
        {
            int frameX = Main.tile[i, j].TileFrameX;
            if (frameX > 0)
            {
                int item = Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, Potions[(frameX / 18)]);
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item);
                }
            }
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.PotionHolder>());
            return true;
        }
    }
}
