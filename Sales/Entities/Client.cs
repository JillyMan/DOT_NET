namespace Entities
{
	public class Client : IBaseClass
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Client(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
