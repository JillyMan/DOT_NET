namespace Entities
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public Product() { }

		public override string ToString()
		{
			return $"Product[ ID={Id}, Name={Name} ]";
		}
	}
}
