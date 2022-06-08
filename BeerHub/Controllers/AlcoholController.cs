using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;

namespace BeerHub.Controllers
{
    [Route("api/alcohol")]
    [ApiController]
    public class AlcoholController : ControllerBase
    {
        
        Alcohol[] alcohols = new Alcohol[]
        {
            new Alcohol { ID=1, Type="Beer", Ingredients={  } },
           new Alcohol { ID=2, Type="Wine", Ingredients={  } },
           new Alcohol { ID=3, Type="Vodka", Ingredients={  } },
        };

        [HttpGet]
        public IEnumerable<Alcohol> GetAllAlcohols()
        {
            return alcohols;
        }

        [Route("api/alcohol/{id}")]
        [HttpGet]
        public IActionResult GetAlcohol(int id)
        {
            var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
            if(alcohol == null)
            {
                return NotFound();
            }
            return Ok(alcohol);
        }

        [Route("api/new-alchohol")]
        [HttpPost]
        public IActionResult NewAlcohol(Alcohol newAlcohol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            alcohols.Prepend(newAlcohol);
            return Ok(alcohols.Append(newAlcohol));
        }

        [Route("api/alcohol/new-ingredients")]
        [HttpPost]
        public IActionResult NewIngredients(int id, List<string> newIngredients)
        {
            var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
            if (alcohol == null)
            {
                return NotFound();
            }
            alcohol.Ingredients = new List<string>(newIngredients);

            return Ok(alcohol);
        }
    }
}
