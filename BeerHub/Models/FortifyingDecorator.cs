using System;

namespace BeerHub.Models
{
	public class FortifyingDecorator
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Distilled AddedLiquor { get; set; }
		public FortifyingDecorator()
		{
		}

		public FortifyingDecorator(Distilled distilled)
		{
			AddedLiquor = distilled;
		}
	}
}

