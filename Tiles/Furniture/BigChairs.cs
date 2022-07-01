using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class BigChairs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/BigChairs";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/BigChairsHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Beanbag Chair");
            AddMapEntry(new Color(204, 204, 204), name);
            name = CreateMapEntryName("Armchair");
            name.SetDefault("Armchair");
            AddMapEntry(new Color(204, 204, 204), name);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Chairs };
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int direction = info.TargetDirection = (tile.TileFrameX < 36) ? -1 : 1;
            info.AnchorTilePosition.X = (tile.TileFrameX is 0 or 54) ? ((direction * -1) + i) : i;
            info.AnchorTilePosition.Y = (tile.TileFrameY % 38 == 0) ? (j + 1) : j;
            if (Main.tile[i, j].TileFrameY < 56)
            {
                info.VisualOffset.X += 4;
            }
            else
            {
                info.VisualOffset.X += 2;
                info.VisualOffset.Y += 2;
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
            { ModContent.ItemType<Items.PaintableBeanbag>(),
              ModContent.ItemType<Items.PaintableArmchair>() };

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

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (Main.tile[i, j].TileFrameY == 56)
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                spriteBatch.Draw(
                    ModContent.Request<Texture2D>(Texture + "Wood").Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 + 12 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(Main.tile[i, j].TileFrameX, 0, 18, 6),
                    Lighting.GetColor(i, j));
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameY / 38)]);
        }
    }
}
