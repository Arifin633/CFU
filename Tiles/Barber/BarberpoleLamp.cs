using Microsoft.Xna.Framework;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class BarberpoleLamp : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Barber/BarberpoleLamp";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;
            Main.tileWaterDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 18;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 19 };

            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.Width = 1;
            TileObjectData.newAlternate.Height = 3;
            TileObjectData.newAlternate.CoordinateWidth = 16;
            TileObjectData.newAlternate.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newAlternate.StyleHorizontal = true;
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newAlternate.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            TileObjectData.addAlternate(1);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.Width = 1;
            TileObjectData.newAlternate.Height = 3;
            TileObjectData.newAlternate.CoordinateWidth = 16;
            TileObjectData.newAlternate.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newAlternate.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
            TileObjectData.addAlternate(2);
            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Barber's Pole");
            AddMapEntry(new Color(133, 213, 247), name);
            AnimationFrameHeight = 54;
            DustType = 0;
            TileID.Sets.DisableSmartCursor[Type] = true;
            //	torch = true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                frame = ++frame % 8;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX <= 54)
            {
                r = 1.0f;
                g = 1.0f;
                b = 0.9f;
            }
            else
            {
                r = 0.2f;
                g = 0.2f;
                b = 0.5f;
            }
        }

        public override void HitWire(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX >= 54)
            { CFUtils.ShiftTileX(i, j, 1, 3, (short)-54, false, true); }
            else { CFUtils.ShiftTileX(i, j, 1, 3, (short)54, false, true); }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.BarberpoleLamp>());
        }
    }
}
