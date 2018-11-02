namespace ShopShoes.Core.Model.Shoes.Season.SpringAutumn
{
	public class Oxford : AbstractShoes, IShoesSpringAutumn
	{
		public Oxford(int size, int price, string brand, TypeColor color, TypeMaterial material, TypeShoes type) :
			base(size, price, brand, color, material, type)
		{
		}
	}
}
