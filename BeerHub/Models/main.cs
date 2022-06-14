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
      loadCocktails();
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

    public void loadCocktails()
    {
      Collection<Cocktails> tmp = new Collection<Cocktails>();
      tmp.Add(new Cocktails("Pisco Punch", new Collection<string> { "pisco", "pineapple", "lemon", "orange", "cloves","Champagne"}, 10.2));
      tmp.Add(new Cocktails("Sidecar", new Collection<string> { "brandy", "lemon", "riple sec" }, 10.2));
      tmp.Add(new Cocktails("Blood & Sand", new Collection<string> { "whisky", "sweet vermouth", "cherry liqueur", "orange juice"}, 10.2));
      tmp.Add(new Cocktails("Irish Coffee", new Collection<string> { "coffee", " Irish whiskey", "cream" }, 10.2));

      foreach (var temp in tmp)
      {
        cc.AddCocktails(temp);
      }
    }

  }
}
