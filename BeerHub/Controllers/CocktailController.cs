using BeerHub.Database;
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

	[Route("GetAllCocktails/")]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Cocktails>>> GetAllCocktails()
	{
		return await _db.cocktails.ToListAsync();
	}

	[Route("GetCocktailsByAlcohol/{name}")]
	[HttpGet]
	public List<Cocktails> GetCocktailsbyAlcohol(string name)
	{
	var cocktailList = new List<Cocktails>();
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
			cocktailList.Add(cocktails);
		  }
		}
		}
		return cocktailList;
	}

	[Route("UpdateCocktail/{id}")]
	[HttpPatch]
	public async Task<ActionResult<IEnumerable<Cocktails>>> UpdateCocktail(int id, Cocktails newCocktail)
	{
		Cocktails cocktail = await _db.cocktails.FirstOrDefaultAsync(p => p.CocktailsId == id);
		
		cocktail.CocktailIngredients = newCocktail.CocktailIngredients ?? newCocktail.CocktailIngredients;
		cocktail.CocktailName = newCocktail.CocktailName ?? newCocktail.CocktailName;
		cocktail.Percentage = newCocktail.Percentage;

		await _db.SaveChangesAsync();

			return Ok();       
	}

	[Route("DeleteCocktail/{cocktailId}")]
	[HttpDelete]
	public async Task<ActionResult> DeleteProduct(int cocktailId)
	{
	  Cocktails cocktail = await _db.cocktails.FirstOrDefaultAsync(p => p.CocktailsId == cocktailId);
	  _db.cocktails.Remove(cocktail);

	  await _db.SaveChangesAsync();

	  return StatusCode(201);
	}
  }
}
