using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ChadsFurnitureUpdated
{
    public class CFU : Mod
    {
        public override void PostSetupContent()
        {
            CFUHooks.SetupHooks();
        }
    }

    public class CFUSystem : ModSystem
    {
        public override void PostDrawTiles()
        {
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            for (int count = 0; count < 2; count++)
                for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[count]; i++)
                    if (CFUTileDraw.SpecialPositionsCount[count] < 5000) // Don't draw past the array size.
                        switch (count)
                        {
                            case 0:
                                CFUTileDraw.DrawHangingTile(CFUTileDraw.SpecialPositions[0][i]);
                                break;
                            case 1:
                                CFUTileDraw.DrawHangingVine(CFUTileDraw.SpecialPositions[1][i]);
                                break;
                        }

            Main.spriteBatch.End();

            /* Since this function, and thus the drawing of the tiles, is called
               a lot more often than the addition of the coordinates themselves,
               we must delay resetting the values of `SpecialPositionsCount'
               until the next update, otherwise we will end up with a gap where
               the tiles aren't being drawn at all, as the count would be zero */
            CFUTileDraw.ResetOnNextAddition = true;
        }
    }
}
