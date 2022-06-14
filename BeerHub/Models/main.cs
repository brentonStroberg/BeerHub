using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Main
  {

    private static AlcoholComposite ac;
    private static CocktailsComposite cc;

    public Main()
    {
      ac = new AlcoholComposite();
      cc = new CocktailsComposite();
    }

    #region Gets
    public Alcohols GetAlcohol(string name)
    {
      return ac.GetAlcohol(name);
    }

    public string UpVote(string name)
    {
      return ac.UpVote(name);
    }

    public string Downvote(string name)
    {
      return ac.DownVote(name);
    }

    public string GetVotes(string name)
    {
      return ac.GetVotes(name);
    }

    public Collection<Alcohols> GetAllAlcohols()
    {
      return ac.GetAllAlcohols();
    }

    public Cocktails GetCocktails(string name)
    {
      return cc.GetCocktails(name);
    }


    #endregion

  }
}
