using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BeerHub.Interfaces
{
    public class Cocktail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> AlcoholMix { get; set; } //Change to List<Alcohol>
        public CocktailIngredients Ingredients { get; set; }
    }
}
