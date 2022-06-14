﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using BeerHub.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class AlcoholController : ControllerBase
  {
    static Main main = new Main();

    #region Gets
    [Route("GetBeer/{name}")]
    [HttpGet]
    public Alcohol GetBeer(string name)
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Collection<Alcohol> GetAllAlcohols()
    {
      return main.GetAllAlcohols();
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
