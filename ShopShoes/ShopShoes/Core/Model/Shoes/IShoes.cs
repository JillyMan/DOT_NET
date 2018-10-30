namespace ShopShoes.Core.Model.Shoes
{
	public interface IShoes
	{
		int Size { get; }
		int Price { get; }
		TypeColor Color { get; }
		TypeMaterial Material { get; }
		TypeShoes Type { get; } 
	}
}
