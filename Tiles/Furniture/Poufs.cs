using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
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
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pouf");
            AddMapEntry(new Color(183, 58, 71), name);
            DustType = 0;
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
            int direction = info.TargetDirection = info.RestingEntity.direction;
            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;
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
                0 /* ModContent.ItemType<Items.PoufSandstone>(), */
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

        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(Main.tile[i, j].TileFrameY / 18)]);
            return true;
        }
    }
}
