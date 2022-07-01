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
    class OrnateThrones : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/OrnateThrones";
        public override string HighlightTexture => "CFU/Textures/Tiles/Furniture/OrnateThronesHighlight";

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            /* NPCs only sit in chairs and toilets. */
            // TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.Origin = new Point16(0, 4);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Throne");
            AddMapEntry(new Color(224, 160, 42), name);
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

            if (tile.TileFrameY != 72)
                info.AnchorTilePosition.Y = (j + ((72 - tile.TileFrameY) / 16));
            else info.AnchorTilePosition.Y = j;
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

        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.tile[i, j].TileFrameX >= 54)
            {
                type = DustID.Platinum;
            }
            else
            {
                type = DustID.Gold;
            }
            return true;
        }

        static readonly int[] Styles =
            { ModContent.ItemType<Items.OrnateGoldThrone>(),
              ModContent.ItemType<Items.OrnatePlatinumThrone>() };

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = Styles[(Main.tile[i, j].TileFrameX / 54)];
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Styles[(frameX / 54)]);
        }
    }
}
