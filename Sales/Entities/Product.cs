namespace Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public Product() { }

		public Product(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public override string ToString()
		{
			return $"Product[ ID={Id}, Name={Name} ]";
		}
	}
}
