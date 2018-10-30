namespace ShopShoes.Core.Model.Shoes.Season.Winter
{
	public class Boots : AbstractShoes, IShoesWinter
	{
		public Boots(int size, int price, TypeMaterial material, TypeShoes type) : 
			base(size, price, material, type)
		{
		}
	}
}
