using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Whiskey: Alcohol
  {

    public Whiskey()
    {

    }

    public Whiskey(string name, string type, double percentage)
    {
      Name = name;
      Type = type;
      Percentage = percentage;
    }

  }
}
