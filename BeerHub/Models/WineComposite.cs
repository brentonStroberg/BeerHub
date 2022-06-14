using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class WineComposite
  {
    #region Privates
    private Collection<Wine> wineCollection;
    private string type;
    #endregion


    #region Properties
    public Collection<Wine> WineCollection
    {
      get { return wineCollection; }
      set
      {
        if (wineCollection != value)
        {
          wineCollection = value;
        }
      }
    }

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
    #endregion

    #region Methods
    public void AddAlcohol(Wine wine)
    {
      if (wine.Type == Type)
      {
        WineCollection.Add(wine);
      }
    }

    public void UpVote(string name)
    {
      Wine b = WineCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.UpVote();
      }
    }

    public void DownVote(string name)
    {
      Wine b = WineCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.DownVote();
      }
    }
    public Wine GetAlcohol(string name)
    {
      return WineCollection.Where(x => x.Name == name).First();
    }

    public string GetVotes(string name)
    {
      var a = WineCollection.Where(z => z.Name == name).First();
      return "Upvotes: " + a.Upvote + ", Downvote: " + a.Downvote;
    }

    public bool CheckForBeer(string name)
    {
      var a = WineCollection.Where(z => z.Name == name);
      if (a.Count() != 0)
        return true;
      return false;
    }
    public int GetNumOfUpvotes(string name)
    {
      var beer = WineCollection.Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Upvote;
      }
      return -1;
    }

    public int GetNumDownVotes(string name)
    {
      var beer = WineCollection.Select(x => x).Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Downvote;
      }
      return -1;
    }

    public Collection<Wine> GetAllAlcohols()
    {
      return WineCollection;
    }
    #endregion

    #region CTOR
    public WineComposite(Wine wine)
    {
      Type = wine.Type;
      WineCollection = new Collection<Wine>();
      WineCollection.Add(wine);
    }

    public WineComposite()
    {

    }
    #endregion
  }
}
