using System;

namespace BeerHub.Models
{
	public class Fermented : Alcohol
	{
		public int FermentationTimeDays { get; set; }
		public Fermented()
		{
		}
	}
}

