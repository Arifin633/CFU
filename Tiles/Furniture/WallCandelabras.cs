using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class WallCandelabras : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/WallCandelabras";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wall Candelabra");
            AddMapEntry(new Color(224, 160, 42), name);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY < 36)
                CFUtils.ShiftTileY(i, j, 36, skipWire: true);
            else
                CFUtils.ShiftTileY(i, j, 0, set: true, skipWire: true);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.WallCandelabraGold>(),
                             ModContent.ItemType<Items.WallCandelabraPlatinum>(),
                             ModContent.ItemType<Items.WallCandelabraBoreal>(),
                             ModContent.ItemType<Items.WallCandelabraPalm>(),
                             ModContent.ItemType<Items.WallCandelabraMahogany>(),
                             ModContent.ItemType<Items.WallCandelabraEbon>(),
                             ModContent.ItemType<Items.WallCandelabraShade>(),
                             ModContent.ItemType<Items.WallCandelabraPearl>(),
                             ModContent.ItemType<Items.WallCandelabraDynasty>(),
                             ModContent.ItemType<Items.WallCandelabraSpooky>(),
                             ModContent.ItemType<Items.WallCandelabraLiving>(),
                             ModContent.ItemType<Items.WallCandelabraCactus>(),
                             ModContent.ItemType<Items.WallCandelabraPumpkin>(),
                             ModContent.ItemType<Items.WallCandelabraMushroom>(),
                             ModContent.ItemType<Items.WallCandelabraGlass>(),
                             ModContent.ItemType<Items.WallCandelabraSteampunk>(),
                             ModContent.ItemType<Items.WallCandelabraSunplate>(),
                             ModContent.ItemType<Items.WallCandelabraIce>(),
                             ModContent.ItemType<Items.WallCandelabraHoney>(),
                             ModContent.ItemType<Items.WallCandelabraGel>(),
                             ModContent.ItemType<Items.WallCandelabraMeteor>(),
                             ModContent.ItemType<Items.WallCandelabraGranite>(),
                             ModContent.ItemType<Items.WallCandelabraMarble>(),
                             ModContent.ItemType<Items.WallCandelabraBone>(),
                             ModContent.ItemType<Items.WallCandelabraFlesh>(),
                             ModContent.ItemType<Items.WallCandelabraLizard>(),
                             ModContent.ItemType<Items.WallCandelabraBlue>(),
                             ModContent.ItemType<Items.WallCandelabraGreen>(),
                             ModContent.ItemType<Items.WallCandelabraPink>(),
                             ModContent.ItemType<Items.WallCandelabraObsidian>(),
                             ModContent.ItemType<Items.WallCandelabraGolden>(),
                             ModContent.ItemType<Items.WallCandelabraMartian>(),
                             ModContent.ItemType<Items.WallCandelabraCrystal>() };

            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, styles[(frameX / 36)]);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameY < 36)
            {
                switch (Main.tile[i, j].TileFrameX / 36)
                {
                    case 2: /* Boreal */
                        r = 0f;
                        g = 0.9f;
                        b = 1f;
                        break;
                    case 5: /* Ebonwood */
                        r = 0.85f;
                        g = 0.6f;
                        b = 1f;
                        break;
                    case 7: /* Pearlwood */
                        r = 1f;
                        g = 0.97f;
                        b = 0.85f;
                        break;
                    case 10: /* Living Wood */
                        r = 1f;
                        g = 1f;
                        b = 0.6f;
                        break;
                    case 11: /* Cactus */
                        r = 0.95f;
                        g = 0.95f;
                        b = 0.5f;
                        break;
                    case 13: /* Mushroom */
                        r = 0.37f;
                        g = 0.8f;
                        b = 1f;
                        break;
                    case 16: /* Skyware */
                        r = 1f;
                        g = 1f;
                        b = 0.7f;
                        break;
                    case 17: /* Frozen */
                        r = 0.75f;
                        g = 0.85f;
                        b = 1f;
                        break;
                    case 19: /* Slime */
                        r = 0.25f;
                        g = 0.7f;
                        b = 1f;
                        break;
                    case 21: /* Granite */
                        r = 0.9f;
                        g = 0.75f;
                        b = 1f;
                        break;
                    case 24: /* Flesh */
                        r = 1f;
                        g = 0.6f;
                        b = 0.6f;
                        break;
                    case 26: /* Blue Dungeon */
                        r = 0.35f;
                        g = 0.5f;
                        b = 0.3f;
                        break;
                    case 27: /* Green Dungeon */
                        r = 0.34f;
                        g = 0.4f;
                        b = 0.31f;
                        break;
                    case 28: /* Pink Dungeon */
                        r = 0.25f;
                        g = 0.32f;
                        b = 0.5f;
                        break;
                    case 29: /* Obsidian */
                        r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
                        g = 0.3f;
                        b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
                        break;
                    case 32: /* Crystal */
                        Vector3 vector = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
                        r = vector.X;
                        g = vector.Y;
                        b = vector.Z;
                        break;
                    default:
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameY < 36)
                CFUTileDraw.DrawFlame(i, j, spriteBatch);
        }
    }
}
