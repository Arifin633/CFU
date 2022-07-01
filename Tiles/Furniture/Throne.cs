using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    class Throne : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Throne";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/ThroneHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Origin = new Point16(0, 3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Throne");
            AddMapEntry(new Color(128, 151, 184), name);
            DustType = DustID.Platinum;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            var frameX = tile.TileFrameX % 54;

            info.TargetDirection = info.RestingEntity.direction;
            if (frameX == 0)
                info.AnchorTilePosition.X = (i + 1);
            else if (frameX == 36)
                info.AnchorTilePosition.X = (i - 1);
            else info.AnchorTilePosition.X = i;

            if (tile.TileFrameY != 54)
                info.AnchorTilePosition.Y = (j + ((54 - tile.TileFrameY) / 16));
            else info.AnchorTilePosition.Y = j;

            info.VisualOffset.X -= 6;
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

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = ModContent.ItemType<Items.RoyalThrone>();
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.RoyalThrone>());
        }
    }
}
