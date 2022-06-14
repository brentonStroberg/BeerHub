﻿using BeerHub.Interfaces;
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
      Collection<Alcohol> tmp = new Collection<Alcohol>();
      tmp.Add(new Alcohol("American IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohol("EnglishIPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohol("Imperial IPA", "Beer", "India Pale Ales", 4.5));
      tmp.Add(new Alcohol("New England American IPA", "Beer", "India Pale Ales", 6));
      tmp.Add(new Alcohol("West Coast IPA", "Vodka", "India Pale Ales", 5));
      tmp.Add(new Alcohol("American pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohol("Czech pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohol("German pilsner", "Beer", "Pilsner", 5));
      tmp.Add(new Alcohol("American stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohol("American imperial stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohol("Irish dry stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohol("Milk stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohol("Oatmeal stout", "Beer", "Stout", 5));
      tmp.Add(new Alcohol("Oyster stout", "Beer", "Stout", 5));
      foreach(var t in tmp)
      {
        amc.AddAlcohol(t);
      }
    }

    #region Gets
    public bool AddAlcohol(string name)
    {
      return amc.AddAlcohol(new Alcohol("American IPA", "Beer", "India Pale Ales", 4.5));
    }

    public Alcohol GetAlcohol(string name)
    {
      return null;
    }

    public bool UpVote(string name)
    {
      return amc.UpVote(name);
    }

    public bool Downvote(string name)
    {
      return amc.DownVote(name);
    }

    public string GetVotes(string name)
    {
      return amc.GetVotes(name);
    }

    public Collection<Alcohols> GetAllAlcohols()
    {
      return amc.GetAllAlcohols();
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
