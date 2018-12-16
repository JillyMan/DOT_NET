namespace Entities
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Client()
		{}

		public override string ToString()
		{
			return $"Client [ ID={Id}, Name={Name} ]";
		}
	}
}
