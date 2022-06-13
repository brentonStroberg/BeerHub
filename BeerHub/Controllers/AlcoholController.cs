﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace BeerHub.Controllers
{
    [Route("api/alcohol")]
    [ApiController]
    public class AlcoholController : ControllerBase
    {
        //Other method to call dynamoDB
        //private readonly IDynamoDBContext _dynamoDbContext;

        //public AlcoholController(IDynamoDBContext dynamoDBContext)
        //{
        //    _dynamoDbContext = dynamoDBContext;
        //}

        ////Get specific Alcohol
        //[HttpGet]
        //public async Task<IEnumerable<Alcohol>> GetAlcohol(string type)
        //{
        //    return await _dynamoDbContext.QueryAsync<Alcohol>(type).GetRemainingAsync();
        //}

        //Ready for DB integration... maybe

        //private readonly IAmazonDynamoDB dynamoDB;
        //public AlcoholController(IAmazonDynamoDB dynamoDB)
        //{
        //    this.dynamoDB = dynamoDB;
        //}

        //public async Task<Alcohol[]> GetAlcohols()
        //{
        //    //Get all in table
        //    //Expensive function
        //    var result = await dynamoDB.ScanAsync(new ScanRequest
        //    {
        //        TableName = "alcohol-table"
        //    });

        //    if(result != null && result != null)
        //    {
        //        var alcohols = new List<Alcohol>();
        //        foreach(var item in result.Items)
        //        {
        //            item.TryGetValue("Type", out var type);
        //            //Other fields
        //            //Other fields

        //            alcohols.Add(new Alcohol
        //            {
        //                Type = type?.S
        //            });
        //        }
        //        return alcohols.ToArray();
        //    }
        //    return Array.Empty<Alcohol>();
        //}

        Alcohol[] alcohols = new Alcohol[]
        {
           new Alcohol 
           { 
               ID=1, Type="Beer", 
               Ingredients= new List<string>{"Barley", "Hopps"},
               ProcessStatus="Fermented",
               ferment= new Fermented{ID=1, FermentationTime=3} 
           },

           new Alcohol 
           {
               ID=2, Type="Wine",
               Ingredients= new List<string>{"Red Grapes, White Grapes"},
               ProcessStatus="Fermented",
               ferment= new Fermented{ID=2, FermentationTime=12} 
           },

           new Alcohol 
           {
               ID=3, Type="Vodka",
               Ingredients= new List<string>{"Potatoes"},
               ProcessStatus="Distilled",
               distil= new Distilled{ID=3, DistilType="Base Liqour"},
               ferment= new Fermented{}
           },
        };

        [HttpGet]
        public IEnumerable<Alcohol> GetAllAlcohols()
        {
            return alcohols;
        }

        [Route("{id}")]
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

        [Route("new-alchohol")]
        [HttpPost]
        public IActionResult NewAlcohol(Alcohol newAlcohol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            alcohols.Append(newAlcohol);
            return Ok(alcohols.Append(newAlcohol));
        }

        [Route("new-ingredients")]
        [HttpPost]
        public IActionResult NewIngredients(int id, List<string> newIngredients)
        {
            var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
            if (alcohol == null)
            {
                return NotFound("No ingredients listed");
            }

            if(newIngredients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                alcohol.Ingredients = new List<string>(newIngredients);
            }
            return Ok(alcohol);
        }

        [Route("process-type")]
        [HttpGet]
        public IActionResult GetProcessType(string type)
        {
            var processType = alcohols.FirstOrDefault((p) => p.Type == type);
            if(processType == null)
            {
                return NotFound();
            }
            return Ok(processType.ProcessStatus);
        }

        [Route("get-alcohol-by-process")]
        [HttpGet]
        public IActionResult GetAlcoholByProcess(string process)
        {
            var alcoholType = alcohols.Where(p=>p.ProcessStatus.Contains(process));

            if (alcoholType.Count() == 0)
            {
                return NotFound();
            }
            return Ok(alcoholType);
        }
    }
}
