using System;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Tiles = CFU.Tiles;
using Items = CFU.Items;

namespace ChadsFurnitureUpdated
{
    static class CFUHooks
    {
        public static void SetupHooks()
        {
            /* This hook allows the mod's Miracle Lily Pads to be drawn in
               the same manner as vanilla Lily Pads, that is, not being
               obstructed by water and reacting to ripples and waves. */
            Terraria.IL_Main.DrawTileInWater += (il) =>
            {
                var c = new ILCursor(il);
                c.GotoNext(MoveType.Before, i => i.MatchLdcI4(518));
                c.EmitDelegate<Func<ushort, ushort>>(type =>
                {
                    /* The next value pushed to the stack must be 518
                       for the tile to be drawn as a lily pad.
                       As such, when the type just read matches our tile,
                       we pretend that its value is actually 518. */
                    if (type == ModContent.TileType<Tiles.MiracleLilyPads>())
                        type = 518;
                    return type;
                });
            };

            /* Here we insert a check for our our Fallen Log tile
               type in the occasion when the event which causes
               fairies to spawn from logs is scanning the world
               for appropriate tiles. */
            Terraria.GameContent.Events.IL_MysticLogFairiesEvent.ScanWholeOverworldForLogs += (il) =>
            {
                var c = new ILCursor(il);
                c.GotoNext(MoveType.Before, i => i.MatchLdcI4(488));
                c.EmitDelegate<Func<ushort, ushort>>(type =>
                {
                    /* See comment on the hook above. */
                    if (type == ModContent.TileType<Tiles.FallenLog>())
                        type = 488;
                    return type;
                });
            };

            /* tModLoader has no pre-existing hook for `PreDrawTiles'.
               Thus to hook into this function is the most sensible way to make
               sure our array will get reset neither too early nor too late. */
            if (CFUConfig.WindEnabled())
            {
                Terraria.GameContent.Drawing.IL_TileDrawing.PreDrawTiles += (il) =>
                {
                    var c = new ILCursor(il);
                    c.GotoNext(MoveType.Before, i => i.MatchLdarg(0));
                    c.EmitDelegate<Action>(() =>
                    {
                        CFUTileDraw.SpecialPositionsCount[0] = 0;
                        CFUTileDraw.SpecialPositionsCount[1] = 0;
                        CFUTileDraw.SpecialPositionsCount[2] = 0;
                        CFUTileDraw.SpecialPositionsCount[3] = 0;
                        CFUTileDraw.SpecialPositionsCount[4] = 0;
                    });
                };
            }

            /* The point in time a drawing function is called
               seems to be the sole determinant for drawing order.
               Therefore, to ensure our tiles' drawing order looks
               just like vanilla's, we must hook into this function
               and draw our tiles at the same time as their equivalents.*/
            if (CFUConfig.WindEnabled())
            {
                Terraria.GameContent.Drawing.IL_TileDrawing.PostDrawTiles += (il) =>
                {
                    var c = new ILCursor(il);
                    c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawMultiTileVines"));
                    c.EmitDelegate<Action>(() =>
                    {
                        for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[0]; i++)
                            if (CFUTileDraw.SpecialPositionsCount[0] < 5000 && // Don't draw past the array size.
                                CFUTileDraw.SpecialPositions[0][i] != new Point()) // Don't draw empty coordinates.
                                CFUTileDraw.DrawHangingTile(CFUTileDraw.SpecialPositions[0][i]);
                    });

                    c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawMultiTileGrass"));
                    c.EmitDelegate<Action>(() =>
                    {
                        for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[2]; i++)
                            if (CFUTileDraw.SpecialPositionsCount[2] < 5000 && // Don't draw past the array size.
                                CFUTileDraw.SpecialPositions[2][i] != new Point()) // Don't draw empty coordinates.
                                CFUTileDraw.DrawRisingTile(CFUTileDraw.SpecialPositions[2][i]);
                    });

                    c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawVines"));
                    c.EmitDelegate<Action>(() =>
                    {
                        for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[1]; i++)
                            if (CFUTileDraw.SpecialPositionsCount[1] < 5000 && // Don't draw past the array size.
                                CFUTileDraw.SpecialPositions[1][i] != new Point()) // Don't draw empty coordinates.
                                CFUTileDraw.DrawHangingVine(CFUTileDraw.SpecialPositions[1][i]);
                    });

                    c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawReverseVines"));
                    c.EmitDelegate<Action>(() =>
                    {
                        for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[3]; i++)
                            if (CFUTileDraw.SpecialPositionsCount[3] < 5000 && // Don't draw past the array size.
                                CFUTileDraw.SpecialPositions[3][i] != new Point()) // Don't draw empty coordinates.
                                CFUTileDraw.DrawRisingVine(CFUTileDraw.SpecialPositions[3][i]);
                    });

                    c.GotoNext(MoveType.After, i => i.MatchCall("Terraria.GameContent.Drawing.TileDrawing", "DrawEntities_DisplayDolls"));
                    c.EmitDelegate<Action>(() =>
                    {
                        for (int i = 0; i < CFUTileDraw.SpecialPositionsCount[4]; i++)
                            if (CFUTileDraw.SpecialPositionsCount[4] < 5000 && // Don't draw past the array size.
                                CFUTileDraw.SpecialPositions[4][i] != new Point()) // Don't draw empty coordinates.
                                CFUTileDraw.DrawPlayer(CFUTileDraw.SpecialPositions[4][i]);
                    });
                };
            }

            /* The hook below allows the player to place Cobweb and Ivy
               blocks as long as they border any other tile (as opposed
               to bordering a solid tile, as is the usual condition).
               As these tiles aren't frame-important, I find this to be
               the only perceivable way to unconditionally decide where
               they may or may not be placed. */
            Terraria.IL_Player.PlaceThing_Tiles_BlockPlacementForAssortedThings += (il) =>
            {
                var c = new ILCursor(il);
                c.Next = null;
                c.GotoPrev(MoveType.Before, i => i.MatchRet());
                c.EmitDelegate<Func<bool, bool>>(canPlace =>
                {
                    Player player = Main.LocalPlayer;
                    int type = player.inventory[player.selectedItem].type;
                    if (type == ModContent.ItemType<Items.Cobweb>() ||
                        type == ModContent.ItemType<Items.Ivy>())
                    {
                        return
                            /* Based on the placement code for the
                               Living Fire, Bubbles, and Smoke Blocks. */
                            (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].HasTile ||
                             Main.tile[Player.tileTargetX + 1, Player.tileTargetY].WallType > 0 ||
                             Main.tile[Player.tileTargetX - 1, Player.tileTargetY].HasTile ||
                             Main.tile[Player.tileTargetX - 1, Player.tileTargetY].WallType > 0 ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY + 1].HasTile ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY + 1].WallType > 0 ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY - 1].HasTile ||
                             Main.tile[Player.tileTargetX, Player.tileTargetY - 1].WallType > 0);
                    }
                    else return canPlace;
                });
            };

            /* Here we insert checks for our own "Flexible Tile Wands"
               (the mechanism behind the "Rubblemaker" items) alongside
               vanilla's. */

            Terraria.IL_Item.GetFlexibleTileWand  += (il) =>
            {
                var c = new ILCursor(il);
                c.GotoNext(MoveType.Before, i => i.MatchLdnull());
                c.Remove();
                c.Emit(Mono.Cecil.Cil.OpCodes.Ldloc_0);
                c.EmitDelegate<Func<int, FlexibleTileWand>>(type =>
                {
                    if (type == ModContent.ItemType<Items.RubblemakerPileSmall>())
                    {
                        return FlexibleTileWand.RubblePlacementSmall;
                    }
                    else if (type == ModContent.ItemType<Items.RubblemakerPileMedium>())
                    {
                        return FlexibleTileWand.RubblePlacementMedium;
                    }
                    else if (type == ModContent.ItemType<Items.RubblemakerPileLarge>())
                    {
                        return FlexibleTileWand.RubblePlacementLarge;
                    }
                    else if (type == ModContent.ItemType<Items.RubblemakerStalagmite>())
                    {
                        return CFUTileWand.Stalagmites;
                    }
                    else if (type == ModContent.ItemType<Items.RubblemakerStalactite>())
                    {
                        return CFUTileWand.Stalactites;
                    }
                    else if (type == ModContent.ItemType<Items.RubblemakerPot>())
                    {
                        return CFUTileWand.Pots;
                    }
                    else if (type == ModContent.ItemType<Items.BagCattails>())
                    {
                        return CFUTileWand.BagCattails;
                    }
                    else if (type == ModContent.ItemType<Items.BagFlowers>())
                    {
                        return CFUTileWand.BagFlowers;
                    }
                    else if (type == ModContent.ItemType<Items.BagGrass>())
                    {
                        return CFUTileWand.BagGrass;
                    }
                    else if (type == ModContent.ItemType<Items.BagHerbs>())
                    {
                        return CFUTileWand.BagHerbs;
                    }
                    else if (type == ModContent.ItemType<Items.BagLilyPads>())
                    {
                        return CFUTileWand.BagLilyPads;
                    }
                    else if (type == ModContent.ItemType<Items.BagMushrooms>())
                    {
                        return CFUTileWand.BagMushrooms;
                    }
                    else if (type == ModContent.ItemType<Items.BagOasisVegetation>())
                    {
                        return CFUTileWand.BagOasisVegetation;
                    }
                    else if (type == ModContent.ItemType<Items.BagSeaOats>())
                    {
                        return CFUTileWand.BagSeaOats;
                    }
                    else if (type == ModContent.ItemType<Items.BagSeaweed>())
                    {
                        return CFUTileWand.BagSeaweed;
                    }
                    else if (type == ModContent.ItemType<Items.BagVines>())
                    {
                        return CFUTileWand.BagVines;
                    }
                    else return null;
                });
            };
        }
    }
}
