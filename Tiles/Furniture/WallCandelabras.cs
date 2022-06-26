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
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Wall Candelabra");
            AddMapEntry(new Color(224, 160, 42), name);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY < 36)
                CFUtils.ShiftTileY(i, j, 36, reset: false, skipWire: true);
            else
                CFUtils.ShiftTileY(i, j, 36, reset: true, skipWire: true);
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
                /* Unverified colors.
                   TODO: Use colors from `TileLightScanner.ApplyTileLight'. */
                switch (Main.tile[i, j].TileFrameX)
                {
                    case 72:
                    case 90:
                    case 612:
                    case 630:
                        r = 0.7f;
                        g = 0.85f;
                        b = 1f;
                        break;
                    case 1044:
                    case 1062:
                        r = 0.75f;
                        g = 0.3f;
                        b = 0.75f;
                        break;
                    default:
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
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
