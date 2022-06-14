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
    Collection<Alcohol> alcohols;
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

    public Collection<Alcohol> Alcohols
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
    public bool AddAlcohol(Alcohol alcohol)
    {
      if(alcohol.SpecificType == Type)
      {
        Alcohols.Add(alcohol);
        return true;
      }
      return false;
    }
    #endregion

    #region CTOR
    public AlcoholType(Alcohol alcohol)
    {
      Type = alcohol.SpecificType;
      alcohols = new Collection<Alcohol>();
      alcohols.Add(alcohol);
    }
    #endregion

  }
}
