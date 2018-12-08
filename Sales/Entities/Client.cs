namespace Entities
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Client()
		{}

		public Client(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public override string ToString()
		{
			return $"Client [ ID={Id}, Name={Name} ]";
		}
	}
}
