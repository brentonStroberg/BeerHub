using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Beer : Alcohol
  {

    private int bottleSize;

    public int BottleSize
    {
      get { return bottleSize; }
      set
      {
        if (bottleSize != value)
        {
          bottleSize = value;
        }
      }
    }

    public Beer()
    {

    }

    public Beer(string name, string type, double percentage)
    {
      Name = name;
      Type = type;
      Percentage = percentage;
    }

    public Beer(int bottleSize)
    {
      BottleSize = bottleSize;
    }
  }
}
