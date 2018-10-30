namespace ShopShoes.Core.Model.Shoes.Season.Summer
{
	public class HighHeels : AbstractShoes, IShoesSummer
	{
		public HighHeels(int size, int price, string brand, TypeColor color, TypeMaterial material) :
			base(size, price, brand, color, material, TypeShoes.WOMAN)
		{

		}
	}
}
