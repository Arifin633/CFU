using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class Statues3x3 : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Statues/Statues3x3";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                18
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 54;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Collectable Inaction Figure");
            AddMapEntry(new Color(81, 81, 89), name);
            DustType = 7;
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.StatueSlimeKing>(),
                             ModContent.ItemType<Items.StatueEyeOfCthulhu>(),
                             ModContent.ItemType<Items.StatueEaterOfWorlds>(),
                             ModContent.ItemType<Items.StatueBrainOfCthulhu>(),
                             ModContent.ItemType<Items.StatueQueenBee>(),
                             ModContent.ItemType<Items.StatueSkeletron>(),
                             ModContent.ItemType<Items.StatueWallOfFlesh>(),
                             ModContent.ItemType<Items.StatueDestroyer>(),
                             ModContent.ItemType<Items.StatueSkeletronPrime>(),
                             ModContent.ItemType<Items.StatuePlantera>(),
                             ModContent.ItemType<Items.StatueGolem>(),
                             ModContent.ItemType<Items.StatueDukeFishron>(),
                             ModContent.ItemType<Items.StatueLunaticCultist>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, styles[(frameX / 54)]);
        }
    }
}
