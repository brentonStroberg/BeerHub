using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using BeerHub.Models;
using System.Collections.ObjectModel;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class AlcoholController : ControllerBase
  {
    static Main main = new Main();

    #region Gets
    [Route("GetAlcohol/{name}")]
    [HttpGet]
    public bool GetAlcohol(string name)
    {
      return main.AddAlcohol(name);
    }

    //[Route("GetVotes/{name}")]
    //[HttpGet]
    //public string GetVotes(string name)
    //{
    //  return main.GetVotes(name);
    //}

    //[Route("GetAllAlcohols/")]
    //[HttpGet]
    //public List<List<Alcohol>> GetAllAlcohols()
    //{
    //  return main.GetAllAlcohols();
    //}


    #endregion

    #region Puts
    //[Route("Upvote/{name}")]
    //[HttpGet]
    //public string UpVote(string name)
    //{
    //  return main.UpVote(name);
    //}

    //[Route("Downvote/{name}")]
    //[HttpGet]
    //public string Downvote(string name)
    //{
    //  return main.Downvote(name);
    //}
    #endregion

    #region Delete

    #endregion

    #region Post
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
