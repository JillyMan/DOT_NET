using System;

namespace Entities
{
	public class SourceDataSale
	{
		public int Id { get; set; }
		public Manager Manager { get; set; }
		public DateTime DateCreateFile { get; set; }
	}
}
