namespace ShopShoes.Core.Model.Shoes.Season.Winter
{
	public class Boots : AbstractShoes, IShoesWinter
	{
		public Boots(int size, int price, string brand, TypeColor color, TypeMaterial material, TypeShoes type) : 
			base(size, price, brand, color, material, type)
		{
		}
	}
}
