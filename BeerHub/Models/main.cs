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

    private AlcoholMainCollection amc;
    private CocktailsComposite cc;

    public Main()
    {
      amc = new AlcoholMainCollection();
      cc = new CocktailsComposite();
      loadCocktails();
      loadBeer();
    }

    #region Gets
    public Alcohols GetAlcohol(string name)
    {
      return amc.GetAlcohol(name);
    }

    public bool UpVote(string name)
    {
      return amc.UpVote(name);
    }

    public List<Alcohols> GetAllAlcohols()
    {
      return amc.GetAllAlcohols();
    }

    public Cocktails GetCocktails(string name)
    {
      return cc.GetCocktails(name);
    }
    #endregion

    #region Post

    public bool RemoveAlcohol(string name)
    {
      return amc.RemoveAlcohol(name);
    }

    public bool AddAlcohol(Alcohols alcohol)
    {
      return amc.AddAlcohol(alcohol);
    }
    #endregion

    #region Puts
    public bool Downvote(string name)
    {
      return amc.DownVote(name);
    }

    public string GetVotes(string name)
    {
      return amc.GetVotes(name);
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

    public void loadBeer()
    {
      Collection<Alcohols> tmp = new Collection<Alcohols>();
      tmp.Add(new Alcohols("American IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohols("EnglishIPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohols("Imperial IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohols("New England American IPA", "Beer", "India Pale Ales", 6));
      tmp.Add(new Alcohols("West Coast IPA", "Vodka", "India Pale Ales", 5));
      tmp.Add(new Alcohols("American pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohols("Czech pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohols("German pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohols("American stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohols("American imperial stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohols("Irish dry stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohols("Milk stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohols("Oatmeal stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohols("Oyster stout", "Beer", "Stout", 5));
      foreach (var t in tmp)
      {
        amc.AddAlcohol(t);
      }
    }

  }
}
