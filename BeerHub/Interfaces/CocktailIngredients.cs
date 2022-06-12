using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeerHub.Interfaces
{
    public class CocktailIngredients
    {
        public int ID { get; set; }
        public List<string> Mixers { get; set; }
        public List<string> FruitAndVeg { get; set; }
        public string Ice { get; set; } //Crushed, Ball, Block ets
        public List<string> Garnish { get; set; }
    }
}
