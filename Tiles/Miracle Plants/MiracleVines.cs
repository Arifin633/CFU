using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class MiracleVines : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Miracle Plants/MiracleVines";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 24;
            TileObjectData.newTile.RandomStyleRange = 24;
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { Type };
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacementHook, -1, 0, false);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.AnchorAlternateTiles = new int[] {  };
            // TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.addAlternate(120);
            // TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            // TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { Type };
            // TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            // TileObjectData.addAlternate(144);
            TileObjectData.addTile(Type);
            HitSound = SoundID.Grass;
            AddMapEntry(new Color(23, 177, 76));
            AddMapEntry(new Color(186, 50, 52));
            AddMapEntry(new Color(28, 216, 94));
            AddMapEntry(new Color(33, 171, 207));
            AddMapEntry(new Color(121, 176, 24));
            AddMapEntry(new Color(182, 175, 130));
            AddMapEntry(new Color(182, 175, 130));
            AddMapEntry(new Color(122, 116, 218));
            AddMapEntry(new Color(100, 90, 190));
        }

        public override ushort GetMapOption(int i, int j) => (ushort)(Main.tile[i, j].TileFrameY / 18);

        public int AfterPlacementHook(int i, int j, int type, int style = 0, int direction = 1, int alternate = 0)
        {
            Tile tileAbove = Main.tile[i, (j - 1)];
            if (tileAbove.TileType == Type)
            {
                if ((tileAbove.TileFrameY / 18) == 5)
                {
                    tileAbove.TileFrameY = (18 * 6);
                }
                if ((Main.tile[i, j].TileFrameY / 18) == 5)
                {
                    Main.tile[i, j].TileFrameY = (18 * 6);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                        NetMessage.SendTileSquare(-1, i, j);
                }
                Tile tileAboveAbove = Main.tile[i, (j - 2)];
                if (tileAboveAbove.TileType == Type)
                {
                    tileAbove.TileFrameX = (short)(18 * Main.rand.Next(48, 71));
                }
                else
                {
                    tileAbove.TileFrameX = (short)(18 * Main.rand.Next(24, 47));
                }

                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j - 1));
            }
            return 1;
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 18)
            {
                case 0:
                case 2:
                    type = DustID.GrassBlades;
                    break;
                case 1:
                    type = DustID.CrimsonPlants;
                    break;
                case 3:
                    type = DustID.HallowedPlants;
                    break;
                case 4:
                    type = DustID.JunglePlants;
                    break;
                case 5:
                case 6:
                    type = DustID.Bone;
                    break;
                case 7:
                    type = DustID.CorruptPlants;
                    break;
                case 8:
                    type = DustID.Mothron;
                    break;
            }

            return true;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail || effectOnly)
                return;

            Tile tileAbove = Main.tile[i, (j - 1)];
            if (tileAbove.TileType == Type)
            {
                if (CFUConfig.WindEnabled())
                    CFUTileDraw.AddSpecialPosition(i, (j - 1), CFUTileDraw.SpecialPositionType.RisingTile);

                tileAbove.TileFrameX = (short)(18 * Main.rand.Next(0, 23));
                if (((tileAbove.TileFrameY / 18) == 6) &&
                    (Main.tile[i, (j - 2)].TileType != Type))
                {
                    tileAbove.TileFrameY = (18 * 5);
                }

                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.SendTileSquare(-1, i, (j - 1));
            }
        }


        public override bool Drop(int i, int j)
        {
            int[] styles = { ModContent.ItemType<Items.MiracleVine>(),
                             ModContent.ItemType<Items.MiracleCrimsonVine>(),
                             ModContent.ItemType<Items.MiracleFlowerVine>(),
                             ModContent.ItemType<Items.MiracleHallowedVine>(),
                             ModContent.ItemType<Items.MiracleJungleVine>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroomVine>(),
                             ModContent.ItemType<Items.MiracleGlowingMushroomVine>(),
                             ModContent.ItemType<Items.MiracleCorruptVine>(),
                             ModContent.ItemType<Items.MiracleAshVine>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[Main.tile[i, j].TileFrameY / 18]);
            return true;
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (!CFUConfig.WindEnabled() && (i % 2 == 0))
                spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if (!CFUConfig.WindEnabled())
            {
                offsetY = -2;
            }
        }

        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j - 1].TileType != Type))
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.HangingVine);
        }
    }
}
