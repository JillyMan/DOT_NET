﻿namespace Entities
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
	}
}
