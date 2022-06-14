using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;


namespace BeerHub.Models
{
  public class Cocktails : Alcohol
  {
    private Collection<string> ingredients; 

    public Collection<string> Ingredients
    {
      get { return ingredients; }
      set
      {
        if (ingredients != value)
        {
          ingredients = value;
        }
      }
    }

    public Cocktails(string name, Collection<string> ingredients, double percentage)
    {
      Name = name;
      Ingredients = ingredients;
      Percentage = percentage;
    }

    public Collection<string> getIngredients()
    {
      return Ingredients;
    }
  }
}
