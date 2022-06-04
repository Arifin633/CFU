using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
	public class WallCandelabraPlatinum : ModItem
	{public override string Texture =>"CFU/Textures/Items/Furniture/Wall Candelabras/WallCandelabraPlatinum";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Wall Candelabra");
	CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}	
		
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 22;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 0;
			Item.createTile = ModContent.TileType<Tiles.WallCandelabras>();
			Item.placeStyle = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.PlatinumBar, 5)
			.AddIngredient(ItemID.Torch, 3)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}
