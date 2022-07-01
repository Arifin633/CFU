using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class OrnateToolracks : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Furniture/OrnateToolracks";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                18
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Fireplace Rack");
            AddMapEntry(new Color(224, 160, 42), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
        }

        
        public override bool CreateDust(int i, int j, ref int type)
        {
            if (Main.tile[i, j].TileFrameX >= 36)
            {
                type = DustID.Platinum;
            }
            else
            {
                type = DustID.Gold;
            }
            return true;
        }


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int[] styles = { ModContent.ItemType<Items.OrnateGoldToolrack>(),
                             ModContent.ItemType<Items.OrnatePlatinumToolrack>() };
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, styles[(frameX / 36)]);
        }
    }
}
