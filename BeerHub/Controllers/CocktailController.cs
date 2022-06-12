using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;

namespace BeerHub.Controllers
{
    [Route("api/cocktail")]
    [ApiController]
    public class CocktailController : ControllerBase
    {

        Cocktail[] cocktails = new Cocktail[]
        {
           new Cocktail
           {
               ID = 1,
               Name = "Gin and Vodka Spritz",
               AlcoholMix = new List<string>{"Gin", "Vodka"},
               Ingredients = new CocktailIngredients{
                   ID=1, Mixers = new List<string>{"Sprite", "Simple Syrup"},
                   FruitAndVeg = new List<string>{"Olives"},
                   Ice = "Crushed",
                   Garnish = new List<string> {"Mint", "Orange Twist"},
               }
           },

           new Cocktail
           {
               ID = 2,
               Name = "Sangria",
               AlcoholMix =  new List<string>{"Wine"},
               Ingredients = new CocktailIngredients{
                   ID=1, Mixers = new List<string>{"Sprite", "Fruit Juice"},
                   FruitAndVeg = new List<string>{"Oranges", "Raspberries", "Strawberries"},
                   Ice = "Cubed",
                   Garnish = new List<string> {"Mint"},
               }
           },
        };

        [HttpGet]
        public IEnumerable<Cocktail> GetAllCocktails()
        {
            return cocktails;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCocktail(int id)
        {
            var cocktail = cocktails.FirstOrDefault((p) => p.ID == id);
            if (cocktail == null)
            {
                return NotFound();
            }
            return Ok(cocktail);
        }

        [Route("new-cocktail")]
        [HttpPost]
        public IActionResult NewCocktail(Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            cocktails.Append(cocktail);
            return Ok(cocktails.Append(cocktail));
        }

        [Route("update-cocktail-ingredients/{id}")]
        [HttpPatch]
        public IActionResult UpdateCocktail(int id, CocktailIngredients newIngredients)
        {
            var cocktail = cocktails.FirstOrDefault((p) => p.ID == id);
            if (cocktail == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            cocktail.Ingredients = newIngredients;
            return Ok(cocktail);
        }
    }
}
