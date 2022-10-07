using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tiles = CFU.Tiles;

namespace ChadsFurnitureUpdated
{
    public class GlobalCFUItem : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.Keg)
            {
                Item.createTile = ModContent.TileType<Tiles.Keg>();
            }
            else if (Item.type == ItemID.BlackInk)
            {
                Item.useTurn = true;
                Item.autoReuse = true;
                Item.useAnimation = 15;
                Item.useTime = 10;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.consumable = true;
                Item.createTile = ModContent.TileType<Tiles.Ink>();
            }
        }
    }

    public class CFUSystem : ModSystem
    {
        (RecipeFun, int, int)[] Recipes =
            { (RecipeBathtub, ItemID.BlueDungeonBathtub, ItemID.BlueBrick),
              (RecipeBathtub, ItemID.GreenDungeonBathtub, ItemID.GreenBrick),
              (RecipeBathtub, ItemID.PinkDungeonBathtub, ItemID.PinkBrick),
              (RecipeBathtub, ItemID.ObsidianBathtub, ItemID.Obsidian),
              (RecipeBathtub, ItemID.GoldenBathtub, ItemID.GoldBar),

              (RecipeBed, ItemID.BlueDungeonBed, ItemID.BlueBrick),
              (RecipeBed, ItemID.GreenDungeonBed, ItemID.GreenBrick),
              (RecipeBed, ItemID.PinkDungeonBed, ItemID.PinkBrick),
              (RecipeBed, ItemID.ObsidianBed, ItemID.Obsidian),
              (RecipeBed, ItemID.GoldenBed, ItemID.GoldBar),

              (RecipeBookcase, ItemID.BlueDungeonBookcase, ItemID.BlueBrick),
              (RecipeBookcase, ItemID.GreenDungeonBookcase, ItemID.GreenBrick),
              (RecipeBookcase, ItemID.PinkDungeonBookcase, ItemID.PinkBrick),
              (RecipeBookcase, ItemID.ObsidianBookcase, ItemID.Obsidian),
              (RecipeBookcase, ItemID.GoldenBookcase, ItemID.GoldBar),
              (RecipeBookcase, ItemID.GothicBookcase, ItemID.Wood),

              (RecipeCandelabra, ItemID.BlueDungeonCandelabra, ItemID.BlueBrick),
              (RecipeCandelabra, ItemID.GreenDungeonCandelabra, ItemID.GreenBrick),
              (RecipeCandelabra, ItemID.PinkDungeonCandelabra, ItemID.PinkBrick),
              (RecipeCandelabra, ItemID.ObsidianCandelabra, ItemID.Obsidian),
              (RecipeCandelabra, ItemID.GoldenCandelabra, ItemID.GoldBar),

              (RecipeCandle, ItemID.BlueDungeonCandle, ItemID.BlueBrick),
              (RecipeCandle, ItemID.GreenDungeonCandle, ItemID.GreenBrick),
              (RecipeCandle, ItemID.PinkDungeonCandle, ItemID.PinkBrick),
              (RecipeCandle, ItemID.ObsidianCandle, ItemID.Obsidian),
              (RecipeCandle, ItemID.GoldenCandle, ItemID.GoldBar),

              (RecipeChandelier, ItemID.BlueDungeonChandelier, ItemID.BlueBrick),
              (RecipeChandelier, ItemID.GreenDungeonChandelier, ItemID.GreenBrick),
              (RecipeChandelier, ItemID.PinkDungeonChandelier, ItemID.PinkBrick),
              (RecipeChandelier, ItemID.ObsidianChandelier, ItemID.Obsidian),
              (RecipeChandelier, ItemID.GoldenChandelier, ItemID.GoldBar),

              (RecipeChair, ItemID.BlueDungeonChair, ItemID.BlueBrick),
              (RecipeChair, ItemID.GreenDungeonChair, ItemID.GreenBrick),
              (RecipeChair, ItemID.PinkDungeonChair, ItemID.PinkBrick),
              (RecipeChair, ItemID.ObsidianChair, ItemID.Obsidian),
              (RecipeChair, ItemID.GoldenChair, ItemID.GoldBar),
              (RecipeChair, ItemID.GothicChair, ItemID.Wood),

              (RecipeChest, ItemID.GoldenChest, ItemID.GoldBar),

              (RecipeClock, ItemID.DungeonClockBlue, ItemID.BlueBrick),
              (RecipeClock, ItemID.DungeonClockGreen, ItemID.GreenBrick),
              (RecipeClock, ItemID.DungeonClockPink, ItemID.PinkBrick),
              (RecipeClock, ItemID.ObsidianClock, ItemID.Obsidian),
              (RecipeClock, ItemID.GoldenClock, ItemID.GoldBar),

              (RecipeDoor, ItemID.BlueDungeonDoor, ItemID.BlueBrick),
              (RecipeDoor, ItemID.GreenDungeonDoor, ItemID.GreenBrick),
              (RecipeDoor, ItemID.PinkDungeonDoor, ItemID.PinkBrick),
              (RecipeDoor, ItemID.ObsidianDoor, ItemID.Obsidian),
              (RecipeDoor, ItemID.GoldenDoor, ItemID.GoldBar),
              (RecipeDoor, ItemID.DungeonDoor, ItemID.Wood),

              (RecipeDresser, ItemID.BlueDungeonDresser, ItemID.BlueBrick),
              (RecipeDresser, ItemID.GreenDungeonDresser, ItemID.GreenBrick),
              (RecipeDresser, ItemID.PinkDungeonDresser, ItemID.PinkBrick),
              (RecipeDresser, ItemID.ObsidianDresser, ItemID.Obsidian),
              (RecipeDresser, ItemID.GoldenDresser, ItemID.GoldBar),

              (RecipeLamp, ItemID.BlueDungeonLamp, ItemID.BlueBrick),
              (RecipeLamp, ItemID.GreenDungeonLamp, ItemID.GreenBrick),
              (RecipeLamp, ItemID.PinkDungeonLamp, ItemID.PinkBrick),
              (RecipeLamp, ItemID.ObsidianLamp, ItemID.Obsidian),
              (RecipeLamp, ItemID.GoldenLamp, ItemID.GoldBar),

              (RecipeLantern, ItemID.ObsidianLantern, ItemID.Obsidian),
              (RecipeLantern, ItemID.GoldenLantern, ItemID.GoldBar),
              (RecipeLantern, ItemID.ChainLantern, ItemID.IronBar),
              (RecipeLantern, ItemID.BrassLantern, ItemID.CopperBar),
              (RecipeLantern, ItemID.CagedLantern, ItemID.IronBar),
              (RecipeLantern, ItemID.CarriageLantern, ItemID.IronBar),
              (RecipeLantern, ItemID.AlchemyLantern, ItemID.Glass),
              (RecipeLantern, ItemID.DiablostLamp, ItemID.Silk),
              (RecipeLantern, ItemID.OilRagSconse, ItemID.IronBar),

              (RecipePiano, ItemID.BlueDungeonPiano, ItemID.BlueBrick),
              (RecipePiano, ItemID.GreenDungeonPiano, ItemID.GreenBrick),
              (RecipePiano, ItemID.PinkDungeonPiano, ItemID.PinkBrick),
              (RecipePiano, ItemID.ObsidianPiano, ItemID.Obsidian),
              (RecipePiano, ItemID.GoldenPiano, ItemID.GoldBar),

              (RecipePlatform, ItemID.GoldenPlatform, ItemID.GoldBar),

              (RecipeSink, ItemID.GoldenSink, ItemID.GoldBar),

              (RecipeSofa, ItemID.BlueDungeonSofa, ItemID.BlueBrick),
              (RecipeSofa, ItemID.GreenDungeonSofa, ItemID.GreenBrick),
              (RecipeSofa, ItemID.PinkDungeonSofa, ItemID.PinkBrick),
              (RecipeSofa, ItemID.ObsidianSofa, ItemID.Obsidian),
              (RecipeSofa, ItemID.GoldenSofa, ItemID.GoldBar),

              (RecipeTable, ItemID.BlueDungeonTable, ItemID.BlueBrick),
              (RecipeTable, ItemID.GreenDungeonTable, ItemID.GreenBrick),
              (RecipeTable, ItemID.PinkDungeonTable, ItemID.PinkBrick),
              (RecipeTable, ItemID.ObsidianTable, ItemID.Obsidian),
              (RecipeTable, ItemID.GoldenTable, ItemID.GoldBar),
              (RecipeTable, ItemID.GothicTable, ItemID.Wood),

              (RecipeToilet, ItemID.GoldenToilet, ItemID.GoldBar),

              (RecipeVase, ItemID.BlueDungeonVase, ItemID.BlueBrick),
              (RecipeVase, ItemID.GreenDungeonVase, ItemID.GreenBrick),
              (RecipeVase, ItemID.PinkDungeonVase, ItemID.PinkBrick),
              (RecipeVase, ItemID.ObsidianVase, ItemID.Obsidian),

              (RecipeWorkBench, ItemID.BlueDungeonWorkBench, ItemID.BlueBrick),
              (RecipeWorkBench, ItemID.GreenDungeonWorkBench, ItemID.GreenBrick),
              (RecipeWorkBench, ItemID.PinkDungeonWorkBench, ItemID.PinkBrick),
              (RecipeWorkBench, ItemID.ObsidianWorkBench, ItemID.Obsidian),
              (RecipeWorkBench, ItemID.GoldenWorkbench, ItemID.GoldBar),
              (RecipeWorkBench, ItemID.GothicWorkBench, ItemID.Wood) };


        public delegate Recipe RecipeFun(int type1, int type2);

        static Recipe RecipeGeneric(int resultType, int materialType, int count, int station = TileID.WorkBenches, int quantity = 1)
        {
            var recipe = Recipe.Create(resultType, quantity);
            if (materialType == ItemID.Obsidian)
            {
                int diff = (count / 3);
                count -= diff;
                int count2 = (diff <= 0) ? 1 : diff;
                recipe.AddIngredient(materialType, count);
                recipe.AddIngredient(ItemID.Hellstone, count2);
            }
            else if (materialType == ItemID.Wood)
            {
                recipe.AddRecipeGroup(RecipeGroupID.Wood, count);
            }
            else if (materialType == ItemID.IronBar)
            {
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, count);
            }
            else
            {
                recipe.AddIngredient(materialType, count);
            }
            if (materialType == ItemID.Wood)
            {
                recipe.AddTile(TileID.Sawmill);
            }
            else if (materialType == ItemID.GrayBrick)
            {
                recipe.AddTile(TileID.HeavyWorkBench);
            }
            else if (materialType is ItemID.IronBar or ItemID.CopperBar)
            {
                recipe.AddTile(TileID.WorkBenches);
            }
            else if (station != -1)
            {
                recipe.AddTile(station);
            }
            return recipe;
        }

        static Recipe RecipeBathtub(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 14);
        }

        static Recipe RecipeBookcase(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 20, TileID.Sawmill);
            recipe.AddIngredient(ItemID.Book, 10);
            return recipe;
        }

        static Recipe RecipeBed(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 15, TileID.Sawmill);
            recipe.AddIngredient(ItemID.Silk, 5);
            return recipe;
        }

        static Recipe RecipeCandelabra(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 5);
            recipe.AddIngredient(((materialType == ItemID.Obsidian) ? ItemID.DemonTorch : ItemID.Torch), 3);
            return recipe;
        }

        static Recipe RecipeCandle(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 4);
            recipe.AddIngredient(((materialType == ItemID.Obsidian) ? ItemID.DemonTorch : ItemID.Torch), 1);
            return recipe;
        }

        static Recipe RecipeChair(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 4);
        }

        static Recipe RecipeChandelier(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 4, TileID.Anvils);
            recipe.AddIngredient(((materialType == ItemID.Obsidian) ? ItemID.DemonTorch : ItemID.Torch), 4);
            recipe.AddIngredient(ItemID.Chain, 1);
            return recipe;
        }

        static Recipe RecipeChest(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 8);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            return recipe;
        }

        static Recipe RecipeClock(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 10, TileID.Sawmill);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 6);
            recipe.AddIngredient(ItemID.Glass, 6);
            return recipe;
        }

        static Recipe RecipeDoor(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 6);
        }

        static Recipe RecipeDresser(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 16, TileID.Sawmill);
        }

        static Recipe RecipeLamp(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 3);
            recipe.AddIngredient(((materialType == ItemID.Obsidian) ? ItemID.DemonTorch : ItemID.Torch), 1);
            return recipe;
        }

        static Recipe RecipeLantern(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 6);
            recipe.AddIngredient(((materialType == ItemID.Obsidian) ? ItemID.DemonTorch : ItemID.Torch), 1);
            return recipe;
        }

        static Recipe RecipePiano(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 15, TileID.Sawmill);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.Book, 1);
            return recipe;
        }

        static Recipe RecipePlatform(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 1, -1, 2);
        }

        static Recipe RecipeSink(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 6);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            return recipe;
        }

        static Recipe RecipeSofa(int resultType, int materialType)
        {
            var recipe = RecipeGeneric(resultType, materialType, 5, TileID.Sawmill);
            recipe.AddIngredient(ItemID.Silk, 2);
            return recipe;
        }

        static Recipe RecipeTable(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 8);
        }

        static Recipe RecipeToilet(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 6);
        }

        static Recipe RecipeVase(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 12);
        }

        static Recipe RecipeWorkBench(int resultType, int materialType)
        {
            return RecipeGeneric(resultType, materialType, 10, -1);
        }

        public override void AddRecipes()
        {
            if (CFUConfig.CraftableFurniture())
            {
                foreach (var (fun, result, material) in Recipes)
                {
                    fun(result, material).Register();
                }
            }
        }
    }
}
