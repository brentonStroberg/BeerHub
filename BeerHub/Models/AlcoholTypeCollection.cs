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
    public bool AddAlcohol(Alcohol alcohol)
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

    public string GetVote(string name)
    {
      foreach (var at in AlcoholTypes)
      {
        if (at.FindName(name) == true)
        {
          return at.GetVote(name);
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
    #endregion

    #region CTOR
    public AlcoholTypeCollection(Alcohol alcohol)
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
