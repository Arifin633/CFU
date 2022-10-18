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
            Player player = Main.LocalPlayer;
            if ((player.dead) || (player.mouseInterface) ||
                /* (player.inventory[player.selectedItem].type != item || */
                (Main.mouseLeft && !Grid.ContainsPoint(Main.MouseScreen)))
                UI.UISystem.Interface.SetState(null);
        }

        /* public override void OnInitialize()
        {
            var asset = ModContent.Request<Texture2D>("CFU/Textures/Unused/Bags/Bag", AssetRequestMode.ImmediateLoad);
            Grid = new CFUGrid();
            for (int i = 0; i < 6; i++)
            {
                var cell = new CFUCell();
                var image = new UIImage(asset);
                image.ScaleToFit = true;
                cell.SetPadding(6);
                cell.Append(image);
                cell.OnMouseUp += (_, _) => { UI.UISystem.Interface.SetState(null); };
                Grid.Append(cell);
            }
            Grid.SetPadding(6);
            Append(Grid); 
        } */
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
