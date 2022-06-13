using System;

namespace BeerHub.Models
{
	public class WineDecorator
	{
		public int Id { get; set; }
		public string Name { get; set; }
		private Wine wrappee { get; set; }
		public WineDecorator()
		{
		}

		public WineDecorator(Distilled distilled)
        {
			FortyfyingDecorator fortDec = new FortyfyingDecorator(distilled);
        }
	}
}

