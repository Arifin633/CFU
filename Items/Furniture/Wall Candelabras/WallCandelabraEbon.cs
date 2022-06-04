using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace CFU.Items
{
	public class WallCandelabraEbon : ModItem
	{public override string Texture =>"CFU/Textures/Items/Furniture/Wall Candelabras/WallCandelabraEbon";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Wall Candelabra");
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
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 0;
			Item.createTile = ModContent.TileType<Tiles.WallCandelabras>();
			Item.placeStyle = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Ebonwood, 5)
			.AddIngredient(ItemID.Torch, 3)
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}
