using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using BeerHub.Models;
using System.Collections.ObjectModel;
using BeerHub.Database;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class AlcoholController : ControllerBase
  {

    private readonly DBManager _db;

    public AlcoholController(DBManager db)
    {
      _db = db;
    }

    static Main main = new Main();

    #region Gets
    [Route("GetAlcohol/{name}")]
    [HttpGet]
    public Alcohols GetAlcohol(string name)
    {
      return main.GetAlcohol(name);
    }


    [Route("RemoveAlcohol/{name}")]
    [HttpDelete]
    public bool RemoveAlcohol(string name)
    {
      return main.RemoveAlcohol(name);
    }

    [Route("AddAlcohol/{name}")]
    [HttpPost]
    public bool AddAlcohol(Alcohols name)
    {
      return main.AddAlcohol(name);
    }

    [Route("GetVotes/{name}")]
    [HttpGet]
    public string GetVotes(string name)
    {
      return main.GetVotes(name);
    }

    [Route("GetAllAlcohols/")]
    [HttpGet]
    public List<Alcohols> GetAllAlcohols()
    {
      return main.GetAllAlcohols();
    }

    [Route("GetCocktails/{name}")]
    [HttpGet]
    public Cocktails GetCocktails(string name)
    {
      return main.GetCocktails(name);
    }
    #endregion

    #region Puts
    [Route("Upvote/{name}")]
    [HttpGet]
    public bool UpVote(string name)
    {
      return main.UpVote(name);
    }

    [Route("Downvote/{name}")]
    [HttpGet]
    public bool Downvote(string name)
    {
      return main.Downvote(name);
    }
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
