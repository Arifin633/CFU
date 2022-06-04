using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
	public class WallCandelabraSteampunk : ModItem
	{public override string Texture =>"CFU/Textures/Items/Furniture/Wall Candelabras/WallCandelabraSteampunk";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steampunker Wall Candelabra");
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
			Item.placeStyle = 15;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Cog, 5)
			.AddIngredient(ItemID.Torch, 3)
			.AddTile(TileID.SteampunkBoiler)
			.Register();
		}
	}
}
