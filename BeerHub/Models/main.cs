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

    AlcoholMainCollection amc;

    public Main()
    {
      amc = new AlcoholMainCollection();
      loadBeer();
    }

    public void loadBeer()
    {
      Collection<Booze> tmp = new Collection<Booze>();
      tmp.Add(new Booze("American IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Booze("EnglishIPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Booze("Imperial IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Booze("New England American IPA", "Beer", "India Pale Ales", 6));
      tmp.Add(new Booze("West Coast IPA", "Vodka", "India Pale Ales", 5));
      tmp.Add(new Booze("American pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Booze("Czech pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Booze("German pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Booze("American stout", "Beer", "Stout", 5));
      tmp.Add(new Booze("American imperial stout", "Beer", "Stout", 5));
      tmp.Add(new Booze("Irish dry stout", "Beer", "Stout", 5));
      tmp.Add(new Booze("Milk stout", "Beer", "Stout", 5));
      tmp.Add(new Booze("Oatmeal stout", "Beer", "Stout", 5));
      tmp.Add(new Booze("Oyster stout", "Beer", "Stout", 5));
      foreach(var t in tmp)
      {
        amc.AddAlcohol(t);
      }
    }

    #region Gets
    public Booze GetAlcohol(string name)
    {
      return amc.GetAlcohol(name);
    }

    public bool UpVote(string name)
    {
      return amc.UpVote(name);
    }

    public List<Booze> GetAllAlcohols()
    {
      return amc.GetAllAlcohols();
    }

    #endregion

    #region Post

    public bool RemoveAlcohol(string name)
    {
      return amc.RemoveAlcohol(name);
    }

    public bool AddAlcohol(Booze alcohol)
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
  }
}
