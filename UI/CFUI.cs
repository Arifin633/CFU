using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using ReLogic.Content;

namespace CFU.UI
{
    public class BagInterfaceState : UIState
    {
        CFUGrid Grid;

        bool SetMousePosition = false;

        static readonly List<ModItem> BagItems = new List<ModItem>
        { ModContent.GetModItem(ModContent.ItemType<Items.BagCattails>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagFlowers>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagGrass>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagHerbs>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagLilyPads>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagMushrooms>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagOasisVegetation>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagSeaOats>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagSeaweed>()),
          ModContent.GetModItem(ModContent.ItemType<Items.BagVines>())};

        public override void Update(GameTime time)
        {
            /* The checks below are not exhaustive; some conditions
               on which this UI should automatically close are either
               non-trivial to be checked, or have been overlooked. */
            Player player = Main.LocalPlayer;
            if ((player.dead) || (player.mouseInterface) ||
                !(BagItems.Exists(item => item.Type == player.inventory[player.selectedItem].type)) ||
                (Main.mouseLeft && !Grid.ContainsPoint(Main.MouseScreen)))
                UI.UISystem.BagInterface.SetState(null);
            base.Update(time);
        }

        public void OpenWindow()
        {
            UI.UISystem.BagInterface.SetState(UI.UISystem.BagState);
            for (int i = 0; i < BagItems.Count; i++)
            {
                var elt = (CFUCell)Grid.Children.ElementAt(i);
                Player player = Main.LocalPlayer;
                if (player.inventory[player.selectedItem].type == BagItems[i].Type)
                    elt.Selected = true;
                else
                    elt.Selected = false;
            }
            SetMousePosition = true;
        }

        public void CloseWindow()
        {
            UI.UISystem.BagInterface.SetState(null);
            /* Necessary to avoid the previous location
               briefly flashing when a new window is open. */
            Grid.Left.Set(-1000, 0);
            Grid.Top.Set(-1000, 0);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (SetMousePosition)
            {
                /* During the time `OnActivate' is called (where these
                   calculations truly belong) mouse X and Y, as well
                   as screen width and height, are inaccurate. */
                float mouseX = Main.mouseX;
                float mouseY = Main.mouseY;
                float screenWidth = Main.screenWidth;
                float screenHeight = Main.screenHeight;

                Grid.Left.Set((mouseX - (Grid.Width.Pixels / 2)), 0);
                Grid.Top.Set((mouseY - (Grid.Height.Pixels / 2)), 0);

                if ((int)Left.Pixels + (int)Width.Pixels + 18 > screenWidth)
                {
                    Grid.Left.Set((float)(screenWidth - (int)Grid.Width.Pixels - 18), 0);
                }
                if ((int)Top.Pixels + (int)Height.Pixels + 18 > screenHeight)
                {
                    Grid.Top.Set((float)(screenHeight - (int)Grid.Height.Pixels - 18), 0);
                }
                SetMousePosition = false;
            }
        }

        void SetupCell(ref CFUCell cell, int i)
        {
            var item = BagItems[i];
            var asset = ModContent.Request<Texture2D>(item.Texture, AssetRequestMode.ImmediateLoad);
            var image = new UIImage(asset);
            image.ScaleToFit = true;
            cell.Append(image);
            cell.OnLeftMouseDown += (_, cell) =>
            {
                foreach (CFUCell elt in Grid.Children)
                {
                    if (elt != cell)
                        elt.Selected = false;
                }
            };
            cell.OnLeftMouseUp += (_, cell) =>
            {
                UI.UISystem.BagInterface.SetState(null);
                Player player = Main.LocalPlayer;
                player.inventory[player.selectedItem].SetDefaults(BagItems[i].Type);
            };
        }

        public override void OnInitialize()
        {
            Grid = new CFUGrid();
            Grid.Left.Set(-1000, 0); /* See: `CloseWindow' */
            Grid.Top.Set(-1000, 0);
            Grid.SetPadding(6);
            for (int i = 0; i < BagItems.Count; i++)
            {
                var cell = new CFUCell();
                cell.SetPadding(6);
                SetupCell(ref cell, i);
                Grid.Append(cell);
            }
            Append(Grid);
        }
    }

    public class UISystem : ModSystem
    {
        public static UserInterface BagInterface;
        public static BagInterfaceState BagState;

        public override void SetStaticDefaults()
        {
            if (!Main.dedServ)
            {
                BagInterface = new UserInterface();
                BagState = new BagInterfaceState();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (BagInterface?.CurrentState != null)
            {
                BagInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Wire Selection"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                                  "CFU: Interface",
                                  delegate
                                  {
                                      if (BagInterface?.CurrentState != null)
                                          BagInterface.Draw(Main.spriteBatch, new GameTime());
                                      return true;
                                  },
                                  InterfaceScaleType.UI));
            }
        }
    }
}
