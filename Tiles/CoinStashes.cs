using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CFU.Tiles
{
    public class CoinStashes : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/CoinStashes";
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 6;
            TileObjectData.newTile.StyleMultiplier = 6;
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(107, 81, 65));
            HitSound = SoundID.Coins;
        }
        
        public override bool CreateDust(int i, int j, ref int type)
        {
            switch (Main.tile[i, j].TileFrameY / 38)
            {
                case 0:
                    type = DustID.Copper;
                    break;
                case 1:
                    type = DustID.Silver;
                    break;
                case 2:
                    type = DustID.Gold;
                    break;
                case 3:
                    type = DustID.Platinum;
                    break;
            }
            return true;
        }
    }
}
