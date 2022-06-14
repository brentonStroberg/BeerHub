using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholMainCollection
  {
    private Collection<AlcoholTypeCollection> alcoholTypeCollection;

    public Collection<AlcoholTypeCollection> AlcoholTypeCollection
    {
      get { return alcoholTypeCollection; }
      set
      {
        if (alcoholTypeCollection != value)
        {
          alcoholTypeCollection = value;
        }
      }
    }

    public bool AddAlcohol(Alcohol alcohol)
    {
      
      foreach(var atc in AlcoholTypeCollection)
      {
        if(atc.Type == alcohol.Type)
        {
          return atc.AddAlcohol(alcohol);
        }
      }
      AlcoholTypeCollection.Add(new AlcoholTypeCollection(alcohol));
      return true;
    }

    public bool UpVote(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.UpVote(name);
        }
      }
      return false;
    }

    public bool DownVote(string name)
    {
      return false;
    }

    public string GetVotes(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.GetVotes(name);
        }
      }
      return false;
    }

    public List<List<Alcohol>> GetAllAlcohols()
    {
      return null;
    }

    public AlcoholMainCollection()
    {
      AlcoholTypeCollection = new Collection<AlcoholTypeCollection>();
    }

  }
}
