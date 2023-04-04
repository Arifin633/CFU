using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;

namespace CFU.Tiles
{
    public class Poufs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/Poufs";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/PoufsHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AdjTiles = new int[] { TileID.Chairs };
            AddMapEntry(new Color(183, 58, 71), this.GetLocalization("MapEntry0"));
            AddMapEntry(new Color(191, 142, 111), this.GetLocalization("MapEntry1"));
            DustType = -1;
        }

        public override ushort GetMapOption(int i, int j)
        {
            if (Main.tile[i, j].TileFrameY >= 80)
                return 1;
            else return 0;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int direction = info.TargetDirection = info.RestingEntity.direction;
            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;
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

        static readonly int[] Styles = {
                0, /* ModContent.ItemType<Items.PoufPrincess>(), */
                ModContent.ItemType<Items.PoufMystic>(),
                ModContent.ItemType<Items.PoufRoyal>(),
                0, /* ModContent.ItemType<Items.PoufSandstone>(), */
                ModContent.ItemType<Items.Stool>()
        };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameY / 18)];
            }
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(Styles[(Main.tile[i, j].TileFrameY / 18)]);
        }
    }
}
