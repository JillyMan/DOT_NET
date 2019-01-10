using System.Collections.Generic;

namespace DAL.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Sale> Sales { get; set; }
	}
}
