using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Chairs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Chairs";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ChairsHighlight";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chair");
            AddMapEntry(new Color(181, 172, 190), name);
            DustType = 7;
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
            info.TargetDirection = (tile.TileFrameX == 0) ? -1 : 1;
            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = (tile.TileFrameY % 38 == 0) ? (j + 1) : j;
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
            { ModContent.ItemType<Items.PrinChair>(),
              0, /* ModContent.ItemType<Items.MysticChair>(), */
              ModContent.ItemType<Items.RoyalChair>(),
              ModContent.ItemType<Items.AltSandstoneChair>()};

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 38)];

                if (Main.tile[i, j].TileFrameX >= 18)
                {
                    player.cursorItemIconReversed = true;
                }
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameY / 38)]); ;
        }

    }
}
