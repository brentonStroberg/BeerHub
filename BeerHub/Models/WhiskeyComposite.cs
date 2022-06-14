using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class WhiskeyComposite
  {
    #region Privates
    private Collection<Whiskey> whiskeyCollection;
    private string type;
    #endregion


    #region Properties
    public Collection<Whiskey> WhiskeyCollection
    {
      get { return whiskeyCollection; }
      set
      {
        if (whiskeyCollection != value)
        {
          whiskeyCollection = value;
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
    public void AddAlcohol(Whiskey whiskey)
    {
      if (whiskey.Type == Type)
      {
        WhiskeyCollection.Add(whiskey);
      }
    }

    public void UpVote(string name)
    {
      Whiskey b = WhiskeyCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.UpVote();
      }
    }

    public void DownVote(string name)
    {
      Whiskey b = WhiskeyCollection.Where(x => x.Name == name).First();
      if (b != null)
      {
        b.DownVote();
      }
    }
    public Whiskey GetAlcohol(string name)
    {
      return WhiskeyCollection.Where(x => x.Name == name).First();
    }

    public string GetVotes(string name)
    {
      var a = WhiskeyCollection.Where(z => z.Name == name).First();
      return "Upvotes: " + a.Upvote + ", Downvote: " + a.Downvote;
    }

    public bool CheckForBeer(string name)
    {
      var a = WhiskeyCollection.Where(z => z.Name == name);
      if (a.Count() != 0)
        return true;
      return false;
    }
    public int GetNumOfUpvotes(string name)
    {
      var beer = WhiskeyCollection.Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Upvote;
      }
      return -1;
    }

    public int GetNumDownVotes(string name)
    {
      var beer = WhiskeyCollection.Select(x => x).Where(y => y.Name == name).First();
      if (beer != null)
      {
        return beer.Downvote;
      }
      return -1;
    }

    public Collection<Whiskey> GetAllAlcohols()
    {
      return WhiskeyCollection;
    }
    #endregion

    #region CTOR
    public WhiskeyComposite(Whiskey whiskey)
    {
      Type = whiskey.Type;
      WhiskeyCollection = new Collection<Whiskey>();
      WhiskeyCollection.Add(whiskey);
    }

    public WhiskeyComposite()
    {

    }
    #endregion
  }
}

