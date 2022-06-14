using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class CocktailsComposite
  {
    #region Privates
    private Collection<Cocktails> cocktailsCollection;
    #endregion

    #region Properties
    public Collection<Cocktails> CocktailsCollection
    {
      get { return cocktailsCollection; }
      set
      {
        if (cocktailsCollection != value)
        {
          cocktailsCollection = value;
        }
      }
    }

    #endregion

    #region Methods
    public void AddCocktails(Cocktails cocktails)
    {
      CocktailsCollection.Add(cocktails);
    }

    public Cocktails GetCocktails(string name)
    {
      return CocktailsCollection.Where(x => x.Name == name).FirstOrDefault();
    }

    public Collection<Cocktails> GetAllCocktails()
    {
      return CocktailsCollection;
    }
    #endregion

    #region CTOR
    public CocktailsComposite(Cocktails cocktails)
    {
      CocktailsCollection = new Collection<Cocktails>();
      CocktailsCollection.Add(cocktails);
    }

    public CocktailsComposite()
    {
      CocktailsCollection = new Collection<Cocktails>();
    }
    #endregion
  }
}
