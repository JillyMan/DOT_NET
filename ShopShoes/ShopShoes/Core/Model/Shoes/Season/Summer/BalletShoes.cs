namespace ShopShoes.Core.Model.Shoes.Season.Summer
{
	public class BalletShoes : AbstractShoes, IShoesSummer
	{
		public BalletShoes(int size, int price, string brand, TypeColor color, TypeMaterial material) :
			base(size, price, brand, color, material, TypeShoes.WOMAN)
		{

		}
	}
}
