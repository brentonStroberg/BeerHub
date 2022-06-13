using System;

namespace BeerHub.Models
{
	public class Wine : Fermented
	{
		public bool Fortified { get; set; }
		public Wine()
		{
		}
	}
}

