using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using ReLogic.Content;

namespace CFU.UI
{
    public class InterfaceState : UIState
    {
        public CFUGrid Grid;

        public override void Update(GameTime time)
        {
            /* The checks below are not exhaustive; some conditions
               on which this UI should automatically close are either
               non-trivial to be checked, or have been overlooked. */
            Player player = Main.LocalPlayer;
            if ((player.dead) || (player.mouseInterface) ||
                !(BagItems.Exists(item => item.Type == player.inventory[player.selectedItem].type)) ||
                (Main.mouseLeft && !Grid.ContainsPoint(Main.MouseScreen)))
                UI.UISystem.Interface.SetState(null);
            base.Update(time);
        }

        public static readonly List<ModItem> BagItems = new List<ModItem>
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

        public bool inSelection = false;

        void SetupCell(ref CFUCell cell, int i)
        {
            var item = BagItems[i];
            var asset = ModContent.Request<Texture2D>(item.Texture, AssetRequestMode.ImmediateLoad);
            var image = new UIImage(asset);
            image.ScaleToFit = true;
            cell.Append(image);
            cell.OnLeftMouseDown += (_, _) => inSelection = true;
            cell.OnLeftMouseUp += (_, _) => inSelection = false;
            cell.OnLeftMouseUp += (_, _) =>
            {
                UI.UISystem.Interface.SetState(null);
                Player player = Main.LocalPlayer;
                player.inventory[player.selectedItem].SetDefaults(BagItems[i].Type);
            };
            cell.OnUpdate += (elt) =>
            {
                if (!inSelection)
                {
                    Player player = Main.LocalPlayer;
                    if (player.inventory[player.selectedItem].type == item.Type)
                    {
                        foreach (CFUCell sis in elt.Parent.Children)
                        {
                            sis.Selected = false;
                        }
                        var cell = (CFUCell)elt;
                        cell.Selected = true;
                    }
                }
            };
        }

        public override void OnInitialize()
        {
            Grid = new CFUGrid();
            for (int i = 0; i < BagItems.Count; i++)
            {
                var cell = new CFUCell();
                cell.SetPadding(6);
                SetupCell(ref cell, i);
                Grid.Append(cell);
            }
            Grid.SetPadding(6);
            Append(Grid);
        }
    }

    public class UISystem : ModSystem
    {
        public static UserInterface Interface;
        public static InterfaceState State;

        public override void SetStaticDefaults()
        {
            if (!Main.dedServ)
            {
                Interface = new UserInterface();
                State = new InterfaceState();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (Interface?.CurrentState != null)
            {
                Interface.Update(gameTime);
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
                                      if (Interface?.CurrentState != null)
                                          Interface.Draw(Main.spriteBatch, new GameTime());
                                      return true;
                                  },
                                  InterfaceScaleType.UI));
            }
        }
    }
}
