using ShopShoes.Core.Shoes.Types;

namespace ShopShoes.Core.Shoes
{
	public class Shoes
	{
		public string Name { get; set; }
		public int Size { get; set; }
		public ShoesTypeMaterial TypeMaterial { get; set; }
		public ShoesPersonType PersonType { get; set; }
		public ShoesSeasonType SeasonType { get; set; }
		public int Price { get; set; }

		public Shoes(int size, string name, ShoesTypeMaterial typeMaterial, ShoesPersonType personType, ShoesSeasonType seasonType, int price)
		{
			this.Name = name;
			this.Size = size;
			this.TypeMaterial = typeMaterial;
			this.PersonType = personType;
			this.SeasonType = seasonType;
			this.Price = price;
		}

		public override string ToString()
		{
			return "Name: " + Name + ", Size" + Size + ", TypeMaterial" + TypeMaterial + ", PersonType: " + PersonType + ", SeasonType: " + SeasonType + ", Price: " + Price;
		}
	}
}
