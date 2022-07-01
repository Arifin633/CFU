using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Sofas : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Sofas";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/SofasHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sofa");
            AddMapEntry(new Color(181, 172, 190), name);
            DustType = -1;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;

            int direction = info.TargetDirection = info.RestingEntity.direction;

            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = (tile.TileFrameY % 38 == 0) ? (j + 1) : j;

            switch (frameY / 38)
            {
                case 0:
                case 1:
                    info.VisualOffset.Y += 1;
                    if (frameX == 18)
                    {
                        info.VisualOffset.X -= 4;
                    }
                    else if ((frameX == 0 && direction == -1) ||
                             (frameX == 36 && direction == 1))
                    {
                        info.VisualOffset.X -= 8;
                    }
                    break;
                case 2:
                    if (frameX == 18)
                    {
                        info.VisualOffset.X -= 4;
                    }
                    else if ((frameX == 0 && direction == -1) ||
                             (frameX == 36 && direction == 1))
                    {
                        info.VisualOffset.Y -= 4;
                        info.VisualOffset.X -= 4;
                    }
                    else
                    {
                        info.VisualOffset.Y -= 4;
                        info.VisualOffset.X -= 6;
                    }
                    break;
                case 3:
                    info.VisualOffset.Y += 1;
                    if (direction == 1) info.VisualOffset.X -= 2;
                    if (frameX == 18)
                    {
                        info.VisualOffset.X -= 4;
                    }
                    else if ((frameX == 0 && direction == -1) ||
                             (frameX == 36 && direction == 1))
                    {
                        info.VisualOffset.X -= 8;
                    }
                    break;
                case 4:
                    info.VisualOffset.Y += 2;
                    if (direction == 1) info.VisualOffset.X -= 2;
                    if (frameX == 18)
                    {
                        info.VisualOffset.X -= 4;
                        info.VisualOffset.Y -= 1;
                    }
                    else if ((frameX == 0 && direction == -1) ||
                             (frameX == 36 && direction == 1))
                    {
                        info.VisualOffset.X -= 8;
                    }
                    break;
            }
            
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.PrinSofa>(),
              ModContent.ItemType<Items.MysticSofa>(),
              ModContent.ItemType<Items.RoyalSofa>(),
              ModContent.ItemType<Items.AltSandstoneSofa>(),
              ModContent.ItemType<Items.PaintableSofa>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 38)];
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            if ((frameY / 38) == 4)
                offsetY = 2;
        }
        
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if ((Main.tile[i, j].TileFrameY / 38 == 4) &&
                (Main.tile[i, j].TileFrameY % 38 != 0))
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture + "Wood").Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 2 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(Main.tile[i, j].TileFrameX, 0, 18, 22),
                    Lighting.GetColor(i, j));
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameY / 38)]);
        }
    }
}
