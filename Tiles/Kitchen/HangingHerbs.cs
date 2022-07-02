﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class HangingHerbs : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Kitchen/HangingHerbs";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Hanging Herb");
            AddMapEntry(new Color(72, 145, 125), name);
            HitSound = SoundID.Grass;
            DustType = -1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.HangingBlinkroot>(),
                             ModContent.ItemType<Items.HangingDaybloom>(),
                             ModContent.ItemType<Items.HangingDeathweed>(),
                             ModContent.ItemType<Items.HangingFireblossom>(),
                             ModContent.ItemType<Items.HangingMoonglow>(),
                             ModContent.ItemType<Items.HangingShiverthorn>(),
                             ModContent.ItemType<Items.HangingWaterleaf>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, styles[(frameX / 18)]);
        }
    }
}
