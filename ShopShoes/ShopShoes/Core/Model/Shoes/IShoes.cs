namespace ShopShoes.Core.Model.Shoes
{
	public interface IShoes
	{
		int Size { get; }
		int Price { get; }
		string Brand { get; }
		TypeColor Color { get; }
		TypeMaterial Material { get; }
		TypeShoes Type { get; } 
	}
}
