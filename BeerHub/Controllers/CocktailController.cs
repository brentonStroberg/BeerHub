﻿using BeerHub.Database;
using BeerHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class CocktailController : ControllerBase
  {
    private readonly DBManager _db;

    public CocktailController(DBManager db)
    {
      _db = db;
    }

    [Route("GetCocktails/{name}")]
    [HttpGet]
    public Cocktails GetCocktailsbyAlcohol(string name)
    {
      for (int j = 1; j <= _db.cocktails.Count(); j++)
      {
        string cocktailByAlc = _db.cocktails.Find(j).CocktailIngredients;
        string[] words = cocktailByAlc.Split(",");
        for (int i = 0; i < words.Length; i++)
        {
          if (name == words[i])
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

    [Route("GetAllCocktails/")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cocktails>>> GetAllCocktails()
    {
      return await _db.cocktails.ToListAsync();
    }

    [HttpDelete("{cocktailId}")]
    public async Task<ActionResult> DeleteProduct(int cocktailId)
    {
      Cocktails cocktail = await _db.cocktails.FirstOrDefaultAsync(p => p.CocktailsId == cocktailId);
      _db.cocktails.Remove(cocktail);

      await _db.SaveChangesAsync();

      return StatusCode(201);
    }
  }
}
