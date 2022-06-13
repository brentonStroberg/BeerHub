using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using BeerHub.Models;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class AlcoholController : ControllerBase
  {


    AlcoholComposite ac = new AlcoholComposite();

    #region Gets
    [Route("GetBeer/{name}")]
    [HttpGet]
    public Alcohol GetBeer(string name)
    {
      return ac.GetAlcohol(name);
    }

    #endregion

    //[HttpGet]
    //public IEnumerable<Alcohol> GetAllAlcohols()
    //{
    //    return alcohols;
    //}

    //[Route("api/alcohol/{id}")]
    //[HttpGet]
    //public IActionResult GetAlcohol(int id)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if(alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(alcohol);
    //}

    //[Route("api/new-alchohol")]
    //[HttpPost]
    //public IActionResult NewAlcohol(Alcohol newAlcohol)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest("Invalid Data");
    //    }
    //    alcohols.Prepend(newAlcohol);
    //    return Ok(alcohols.Append(newAlcohol));
    //}

    //[Route("api/alcohol/new-ingredients")]
    //[HttpPost]
    //public IActionResult NewIngredients(int id, List<string> newIngredients)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if (alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    alcohol.Ingredients = new List<string>(newIngredients);

    //    return Ok(alcohol);
    //}
  }
}
