using System;

namespace BeerHub.Models
{
	public class AlcoholComposite
	{
		public int Id { get; set; }
		public List<Alcohol> children { get; set; }
		public AlcoholComposite()
		{
		}

		public void AddAlcohol(Alcohol alcohol)
		{
			children.Add(alcohol);
		}

		public void RemoveAlcohol(Alcohol alcohol)
		{
			if (children.Contains(alcohol))
			{
				children.Remove(alcohol);
			}
		}
	}
}

