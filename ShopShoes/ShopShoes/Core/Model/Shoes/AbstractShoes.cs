namespace ShopShoes.Core.Model.Shoes
{
	public class AbstractShoes : IShoes
	{
		public int Size	{get; private set;}

		public int Price {get; set;}

		public TypeMaterial Material {get; private set;}

		public TypeShoes Type { get; private set; }

		public TypeColor Color { get; private set; }

		public AbstractShoes(int size, int price, TypeMaterial material, TypeShoes type)
		{
			Size = size;
			Price = price;
			Material = material;
			Type = type;
		}
	}
}
