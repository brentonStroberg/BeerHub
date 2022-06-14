using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Wine:Alcohol
  {
    public Wine()
    {

    }
    public Wine(string name, string type, double percentage)
    {
      Name = name;
      Type = type;
      Percentage = percentage;
    }
  }
}
