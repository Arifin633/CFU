using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChadsFurnitureUpdated;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace CFU.Tiles
{
    public class PlanteraBulb : ModTile
    {
        public override string Texture => "CFU/Textures/Tiles/Plastic/PlanteraBulb";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorAlternateTiles = new int[] { ModContent.TileType<Tiles.PlantPots>() };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(225, 128, 206));
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 21)
            {
                frameCounter = 0;
                frame = ++frame % 4;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (r < 0.5f)
            {
                r = 0.5f;
            }
            if (b < 0.5f)
            {
                b = 0.5f;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short frameX, ref short frameY)
        {
            int potType = ModContent.TileType<Tiles.PlantPots>();
            if ((Main.tile[i, j + 1].TileType == potType) ||
                ((Main.tile[i, j + 1].TileType == Type) &&
                 (Main.tile[i, j + 2].TileType == potType)))
                offsetY = -4;
            else offsetY = 2;
        }

        public override void AnimateIndividualTile(int type, int i, int j, ref int addFrX, ref int addFrY) => addFrY = Main.tileFrame[type] * 36;

        public override bool CreateDust(int i, int j, ref int type)
        {
            type = (!Main.rand.NextBool(3))
                ? DustID.Plantera_Pink : DustID.Plantera_Green;
            return true;
        }


        public override bool PreDraw(int i, int j, SpriteBatch spritebatch) => !(CFUConfig.WindEnabled());

        public override void PostDraw(int i, int j, SpriteBatch spritebatch)
        {
            if ((Main.rand.NextBool(4)) && (Main.rand.NextBool(10)))
            {
                int num = Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.PlanteraBulb);
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 200;
            }

            if ((CFUConfig.WindEnabled()) &&
                (Main.tile[i, j].TileFrameX == 0) &&
                (Main.tile[i, j].TileFrameY == 0))
            {
                CFUTileDraw.AddSpecialPosition(i, j, CFUTileDraw.SpecialPositionType.RisingTile);
            }
        }
    }
}
