using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholType
  {

    #region Privates
    Collection<Booze> alcohols;
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

    public Collection<Booze> Alcohols
    {
      get { return alcohols; }
      set
      {
        if (alcohols != value)
        {
          alcohols = value;
        }
      }
    }
    #endregion

    #region Methods
    public bool AddAlcohol(Booze alcohol)
    {
      if (alcohol.SpecificType == Type)
      {
        Alcohols.Add(alcohol);
        return true;
      }
      return false;
    }

    public bool FindName(string name)
    {
      foreach( var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          return true;
        }
      }
      return false;
    }



    public bool UpVote(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          alc.UpVote();
          return true;
        }
      }
      return false;
    }
    #endregion

    #region CTOR
    public AlcoholType(Booze alcohol)
    {
      Type = alcohol.SpecificType;
      alcohols = new Collection<Booze>();
      alcohols.Add(alcohol);
    }
    #endregion

  }
}
