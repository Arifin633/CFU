using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
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

    public class HairInterfaceState : UIState
    {
        CFUBox Box;
        CFUGrid Grid;
        CFUColorSlider Slider;

        CFUImage[] HairImages;

        Player Player;
        Color oldHairColor;
        int oldHairstyle;

        public override void Update(GameTime time)
        {
            Player player = Main.LocalPlayer;
            if (Main.npcChatText != "" || Main.playerInventory || player.chest != -1 || Main.npcShop != 0 || player.talkNPC != -1 || Main.InGuideCraftMenu)
                CloseWindow(revert: true);
            base.Update(time);
        }

        public void OpenWindow(Player player)
        {
            Player _player = Main.LocalPlayer;
            /* FIXME: This stops the window from opening when it
               would immediately be closed again.  The proper
               behavior would be to get rid of whatever is
               making that happen, e.g. close the player's
               inventory if it's open. */
            bool result = !(Main.npcChatText != "" || Main.playerInventory || _player.chest != -1 || Main.npcShop != 0 || _player.talkNPC != -1 || Main.InGuideCraftMenu);
            if (result)
            {
                UI.UISystem.HairInterface.SetState(UI.UISystem.HairState);
                Player = player;
                var color = Player.hairColor;
                var hsl = Main.rgbToHsl(color);
                oldHairColor = color;
                Slider.Color = color;
                Slider.HSL.Hue = hsl.X;
                Slider.HSL.Saturation = hsl.Y;
                Slider.HSL.Luminance = hsl.Z;
                oldHairstyle = Player.hair;

                foreach (var img in HairImages)
                {
                    img.Color = color;
                }

                for (int i = 0; i < Grid.Children.Count(); i++)
                {
                    var elt = (CFUCell)Grid.Children.ElementAt(i);
                    if (i == Player.hair)
                        elt.Selected = true;
                    else
                        elt.Selected = false;
                }
            }
        }

        public void CloseWindow(bool revert)
        {
            if (revert)
            {
                Player.hairColor = oldHairColor;
                Player.hair = oldHairstyle;
            }
            else if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                Tiles.MannequinHeadTE.SendPacket(Player);
            }

            UI.UISystem.HairInterface.SetState(null);
        }

        public override void OnActivate()
        {
            Box.Left.Set(((Main.screenWidth / 2) - ((Box.GetOuterDimensions().Width * Main.UIScale) / 2)) / Main.UIScale, 0f);
            Box.Top.Set(((Main.screenHeight / 2) + (100 / Main.UIScale) / Main.UIScale), 0f);
        }

        void SetupCell(ref CFUCell cell, int i)
        {
            cell.OnLeftMouseDown += (_, _) => Player.hair = i;
        }

        public override void OnInitialize()
        {
            Box = new CFUBox();
            Grid = new CFUGrid();
            Slider = new CFUColorSlider();
            HairImages = new CFUImage[165];
            var leftBox = new CFUBox();
            var rightBox = new CFUBox();
            var bottomLeftBox = new CFUBox();
            var leftButton = new CFUImage(TextureAssets.ScrollLeftButton);
            var rightButton = new CFUImage(TextureAssets.ScrollRightButton);
            var accept = new UIText("Accept");
            var cancel = new UIText("Cancel");

            /* Main box */
            Box.SetPadding(10);
            Box.DrawFun = (spriteBatch, elt) =>
            {
                var dimensions = elt.GetOuterDimensions();
                Utils.DrawInvBG(spriteBatch,
                                new Rectangle((int)dimensions.X,
                                              (int)dimensions.Y,
                                              (int)dimensions.Width,
                                              (int)dimensions.Height),
                                new Color(50, 50, 118, 255) * 0.8f);
            };
            Box.OnScrollWheel += (e, _) =>
            {
                if (e.ScrollWheelValue > 0)
                {
                    if (Grid.Index >= 5)
                    {
                        Grid.Index -= 5;
                        Grid.Recalculate();
                    }
                }
                else if (Grid.Index <= 145)
                {
                    Grid.Index += 5;
                    Grid.Recalculate();
                }
            };

            /* Left & right container boxes */
            leftBox.Orientation = CFUBox.BoxOrientation.Vertical;
            leftBox.DrawFun = (_, _) => { };
            leftBox.VAlign = 0.5f;
            leftBox.MarginRight = 6;
            rightBox.DrawFun = (_, _) => { };

            /* Hair grid */
            Grid.CellSize = 50;
            Grid.RowConstraints = 5;
            Grid.ColumnConstraints = 3;
            Grid.SetPadding(6);
            Grid.DrawFun = (_, _) => { };
            Grid.OnRecalculate += (_) =>
            {
                if (Grid.Index == 0)
                    leftButton.Visibility = false;
                else
                    leftButton.Visibility = true;

                if (Grid.Index == 150)
                    rightButton.Visibility = false;
                else
                    rightButton.Visibility = true;
            };

            /* Grid cells */
            for (int i = 0; i < 165; i++)
            {
                var cell = new CFUCell();

                Main.instance.LoadHair(i);
                var image = new CFUImage(TextureAssets.PlayerHair[i]);
                image.Area = new Rectangle(0, 0, 40, 56);
                if (i == 163) /* See `Player.GetHairDrawOffset' */
                    image.Offset = new Vector2(0, -2);
                else if (i == 164)
                    image.Offset = new Vector2(-2, 0);
                HairImages[i] = image;

                var texture = ModContent.Request<Texture2D>("CFU/Textures/UI/MannequinHead");
                var headImage = new CFUImage(texture);

                SetupCell(ref cell, i);
                cell.OnLeftMouseDown += (_, cell) =>
                {
                    foreach (CFUCell elt in Grid.Children)
                    {
                        if (elt != cell)
                            elt.Selected = false;
                    }
                };

                cell.SetPadding(6);
                cell.BackgroundColor = new Color(47, 95, 103, 255);
                cell.BorderColor = new Color(25, 40, 55, 255);
                cell.SelectedBackgroundColor = Main.OurFavoriteColor;
                cell.Append(headImage);
                cell.Append(image);
                Grid.Append(cell);
            }

            /* Grid buttons */
            leftButton.VAlign = 0.5f;
            ChadsFurnitureUpdated.CFUtils.SetWidth(leftButton, leftButton.Texture.Width);
            ChadsFurnitureUpdated.CFUtils.SetWidth(leftButton, leftButton.Texture.Height);
            leftButton.OnLeftClick += (_, elt) =>
            {
                if (Grid.Index >= 15)
                {
                    Grid.Index -= 15;
                    Grid.Recalculate();
                }
                else
                {
                    Grid.Index = 0;
                    Grid.Recalculate();
                }
            };

            rightButton.VAlign = 0.5f;
            ChadsFurnitureUpdated.CFUtils.SetWidth(rightButton, rightButton.Texture.Width);
            ChadsFurnitureUpdated.CFUtils.SetWidth(rightButton, rightButton.Texture.Height);
            rightButton.OnLeftClick += (_, elt) =>
            {
                if (Grid.Index <= 135)
                {
                    Grid.Index += 15;
                    Grid.Recalculate();
                }
                else if (Grid.Index < 150)
                {
                    Grid.Index = 150;
                    Grid.Recalculate();
                }
            };

            /* Hair color slider */
            ChadsFurnitureUpdated.CFUtils.SetHeight(Slider, 100);
            ChadsFurnitureUpdated.CFUtils.SetWidth(Slider, 200);
            Slider.OnColorChanged += (elt) =>
            {
                var slider = (CFUColorSlider)elt;
                Player.hairColor = slider.Color;
                foreach (var img in HairImages)
                    img.Color = slider.Color;
            };

            /* Controls box */
            bottomLeftBox.WidthFit = CFUBox.BoxFitting.Fill;
            bottomLeftBox.HAlign = 0.5f;
            bottomLeftBox.PaddingLeft = 10;
            bottomLeftBox.PaddingRight = 10;
            bottomLeftBox.DrawFun = (_, _) => { };

            /* Accept & cancel buttons */
            accept.MarginTop = 20;
            accept.TextColor = new Color(249, 218, 121);
            accept.OnMouseOver += (_, _) =>
                accept.ShadowColor = new Color(164, 42, 42);
            accept.OnMouseOut += (_, _) =>
                accept.ShadowColor = Color.Black;
            accept.OnLeftClick += (_, _) =>
                CloseWindow(revert: false);

            cancel.MarginTop = 20;
            cancel.TextColor = new Color(249, 218, 121);
            cancel.OnMouseOver += (_, _) =>
                cancel.ShadowColor = new Color(164, 42, 42);
            cancel.OnMouseOut += (_, _) =>
                cancel.ShadowColor = Color.Black;
            cancel.OnLeftClick += (_, _) =>
                CloseWindow(revert: true);

            bottomLeftBox.Append(accept);
            bottomLeftBox.Append(cancel);
            leftBox.Append(Slider);
            leftBox.Append(bottomLeftBox);
            rightBox.Append(leftButton);
            rightBox.Append(Grid);
            rightBox.Append(rightButton);
            Box.Append(leftBox);
            Box.Append(rightBox);
            Append(Box);
        }
    }

    public class UISystem : ModSystem
    {
        public static UserInterface BagInterface;
        public static BagInterfaceState BagState;

        public static UserInterface HairInterface;
        public static HairInterfaceState HairState;

        public override void SetStaticDefaults()
        {
            if (!Main.dedServ)
            {
                BagInterface = new UserInterface();
                BagState = new BagInterfaceState();

                HairInterface = new UserInterface();
                HairState = new HairInterfaceState();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (BagInterface?.CurrentState != null)
            {
                BagInterface.Update(gameTime);
            }
            if (HairInterface?.CurrentState != null)
            {
                HairInterface.Update(gameTime);
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
                                      if (HairInterface?.CurrentState != null)
                                          HairInterface.Draw(Main.spriteBatch, new GameTime());
                                      return true;
                                  },
                                  InterfaceScaleType.UI));
            }
        }
    }
}
