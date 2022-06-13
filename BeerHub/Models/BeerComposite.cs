using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class BeerComposite
  {
    #region Privates
    private Collection<Beer> beersCollection;
    private string type;
    #endregion

    #region Properties
    public Collection<Beer> BeersCollection
    {
      get { return beersCollection; }
      set
      {
        if (beersCollection != value)
        {
          beersCollection = value;
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
    public void AddAlcohol(Beer beer)
    {
      if (beer.Type == Type)
      {
        beersCollection.Add(beer);
      }
    }

    public void UpVote(string name)
    {
      Beer b = BeersCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.UpVote();
      }
    }

    public void DownVote(string name)
    {
      Beer b = BeersCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.DownVote();
      }
    }
    public Beer GetAlcohol(string name)
    {
      return BeersCollection.Where(x => x.Name == name).First();
    }

    public string GetVotes(string name)
    {
      var a = BeersCollection.Where(z => z.Name == name).First();
      return "Upvotes: " + a.Upvote +", Downvote: "+ a.Downvote;
    }

    public bool CheckForBeer(string name)
    {
      var a = BeersCollection.Where(z => z.Name == name);
      if (a.Count() != 0)
        return true;
      return false;
    }
    public int GetNumOfUpvotes(string name)
    {
      var beer = BeersCollection.Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Upvote;
      }
      return -1;
    }

    public int GetNumDownVotes(string name)
    {
      var beer = BeersCollection.Select(x => x).Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Downvote;
      }
      return -1;
    }

    public Collection<Beer> GetAllAlcohols()
    {
      return BeersCollection;
    }
    #endregion

    #region CTOR
    public BeerComposite(Beer beer)
    {
      Type = beer.Type;
      BeersCollection = new Collection<Beer>();
      BeersCollection.Add(beer);
    }

    public BeerComposite()
    {

    }
    #endregion
  }
}
