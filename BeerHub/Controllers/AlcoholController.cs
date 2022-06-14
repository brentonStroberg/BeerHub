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

    [Route("Upvote/{name}")]
    [HttpGet]
    public string UpVote(string name)
    {
      return main.UpVote(name);
    }

    [Route("Downvote/{name}")]
    [HttpGet]
    public string Downvote(string name)
    {
      return main.Downvote(name);
    }

    [Route("GetVotes/{name}")]
    [HttpGet]
    public string GetVotes(string name)
    {
      return main.GetVotes(name);
    }

    [Route("GetAllAlcohols/")]
    [HttpGet]
    public Collection<Alcohols> GetAllAlcohols()
    {
      Console.WriteLine(_db.alcohol.Find(1).Type);
      //Console.WriteLine(_db.cocktails.Find(1).CocktailIngredients);
      return main.GetAllAlcohols();
    }

    [Route("GetCocktails/{name}")]
    [HttpGet]
    public Cocktails GetCocktailsbyAlcohol(string name)
    {
      for(int j = 1; j <= _db.cocktails.Count(); j++)
      {
        string cocktailByAlc = _db.cocktails.Find(j).CocktailIngredients;
        string[] words = cocktailByAlc.Split(",");
        for (int i = 0; i < words.Length; i++)
        {
          if(name == words[i])
          {
            Cocktails cocktails = new Cocktails
            {
              CocktailName = _db.cocktails.Find(j).CocktailName,
              CocktailIngredients = _db.cocktails.Find(j).CocktailIngredients,
              Percentage = _db.cocktails.Find(j).Percentage
            };
            return cocktails;
          }
        }
      }
      return null;
    }

    /*[Route("GetAllCocktails/")]
    [HttpGet]
    public Cocktails GetAllCocktails()
    {
      

      return 
    }*/


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
