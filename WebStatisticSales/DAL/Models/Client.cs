﻿using System.Collections.Generic;

namespace DAL.Models
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Sale> Purchases { get; set; }
	}
}
