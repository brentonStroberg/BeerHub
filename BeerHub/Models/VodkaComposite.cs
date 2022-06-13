using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class VodkaComposite
  {
    #region Privates
    private Collection<Vodka> vodkaCollection;
    private string type;
    #endregion

    #region Properties
    public Collection<Vodka> VodkaCollection
    {
      get { return vodkaCollection; }
      set
      {
        if (vodkaCollection != value)
        {
          vodkaCollection = value;
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
    public void AddAlcohol(Vodka vodka)
    {
      if (vodka.Type == Type)
      {
        VodkaCollection.Add(vodka);
      }
    }

    public void UpVote(string name)
    {
      Vodka b = VodkaCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.UpVote();
      }
    }

    public void DownVote(string name)
    {
      Vodka b = VodkaCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.DownVote();
      }
    }
    public Vodka GetAlcohol(string name)
    {
      return VodkaCollection.Where(x => x.Name == name).First();
    }

    public string GetVotes(string name)
    {
      var a = VodkaCollection.Where(z => z.Name == name).First();
      return "Upvotes: " + a.Upvote + ", Downvote: " + a.Downvote;
    }

    public bool CheckForAlcohol(string name)
    {
      var a = VodkaCollection.Where(z => z.Name == name);
      if (a.Count() != 0)
        return true;
      return false;
    }
    public int GetNumOfUpvotes(string name)
    {
      var beer = VodkaCollection.Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Upvote;
      }
      return -1;
    }

    public int GetNumDownVotes(string name)
    {
      var beer = VodkaCollection.Select(x => x).Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Downvote;
      }
      return -1;
    }

    public Collection<Vodka> GetAllAlcohols()
    {
      return VodkaCollection;
    }
    #endregion

    #region CTOR
    public VodkaComposite(Vodka vodka)
    {
      Type = vodka.Type;
      VodkaCollection = new Collection<Vodka>();
      VodkaCollection.Add(vodka);
    }

    public VodkaComposite()
    {

    }
    #endregion
  }
}
