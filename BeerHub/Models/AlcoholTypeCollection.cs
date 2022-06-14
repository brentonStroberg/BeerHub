using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholTypeCollection
  {
    #region privates
    private Collection<AlcoholType> alcoholTypes;
    private string type;
    #endregion

    #region Properties
    public string Type
    {
      get { return type; }
      set
      {
        if (type != value)
        {
          type = value;
        }
      }
    }
    public Collection<AlcoholType> AlcoholTypes
    {
      get { return alcoholTypes; }
      set
      {
        if (alcoholTypes != value)
        {
          alcoholTypes = value;
        }
      }
    }
    #endregion

    #region Methods
    public bool AddAlcohol(Booze alcohol)
    {
      foreach(var at in AlcoholTypes)
      {
        if(at.Type == alcohol.SpecificType)
        {
          return at.AddAlcohol(alcohol);
        }
      }
      AlcoholTypes.Add(new AlcoholType(alcohol));
      return true;
    }

    public string GetVotes(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.GetVotes(name);
        }
      }
      return "";
    }

    public bool UpVote(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.UpVote(name);
        }
      }
      return false;
    }

    public bool DownVote(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.DownVote(name);
        }
      }
      return false;
    }

    public bool RemoveAlcohol(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.RemoveAlcohol(name);
        }
      }
      return false;
    }

    public bool FindName(string name)
    {
      foreach(var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return true;
        }
      }
      return false;
    }

    public Booze GetAlcohol(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.GetAlcohol(name);
        }
      }
      return null;
    }

    public List<Booze> GetAllAlcohols()
    {
      List<Booze> tmp = new List<Booze>();
      foreach(var at in AlcoholTypes)
      {
        tmp.AddRange(at.GetAllAlcohols());
      }
      return tmp;
    }
    #endregion

    #region CTOR
    public AlcoholTypeCollection(Booze alcohol)
    {
      Type = alcohol.Type;
      AlcoholTypes = new Collection<AlcoholType>();
      AlcoholTypes.Add(new AlcoholType(alcohol));
    }

    public AlcoholTypeCollection()
    {

    }

    #endregion

  }
}
