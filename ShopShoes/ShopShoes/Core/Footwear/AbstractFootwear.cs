using ShopShoes.Core.Footwear.Types;

namespace ShopShoes.Core.Footwear
{
	public abstract class AbstractFootwear
	{
		public string Name { get; set; }
		public uint Size { get; private set; }
		public uint Price { get; set; }
		public FootwearTypeMaterial TypeMaterial { get; private set; }
		public FootwearTypePerson PersonType { get; private set; }
		public FootwearTypeSeason SeasonType { get; private set; }

		protected AbstractFootwear(uint size, string name, FootwearTypeMaterial typeMaterial, FootwearTypePerson personType, FootwearTypeSeason seasonType)
		{
			this.Name = name;
			this.Size = size;
			this.TypeMaterial = typeMaterial;
			this.PersonType = personType;
			this.SeasonType = seasonType;
		}

		public override string ToString()
		{
			return "Name: " + Name + ", Size: " + Size + ", TypeMaterial: " + TypeMaterial + ", PersonType: " + PersonType + ", SeasonType: " + SeasonType + ", Price: " + Price;
		}
	}
}
