using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholComposite
  {
    #region Privates

    private Collection<BeerComposite> beerComposites;
    private Collection<WineComposite> wineComposites;
    private Collection<WhiskeyComposite> whiskeyComposites;
    private Collection<VodkaComposite> vodkaComposites;
    #endregion

    #region Properties
    public Collection<BeerComposite> BeerComposites
    {
      get { return beerComposites; }
      set
      {
        if (beerComposites != value)
        {
          beerComposites = value;
        }
      }
    }

    public Collection<VodkaComposite> VodkaComposites
    {
      get { return vodkaComposites; }
      set
      {
        if (vodkaComposites != value)
        {
          vodkaComposites = value;
        }
      }
    }

    public Collection<WineComposite> WineComposites
    {
      get { return wineComposites; }
      set
      {
        if (wineComposites != value)
        {
          wineComposites = value;
        }
      }
    }

    public Collection<WhiskeyComposite> WhiskeyComposites
    {
      get { return whiskeyComposites; }
      set
      {
        if (whiskeyComposites != value)
        {
          whiskeyComposites = value;
        }
      }
    }
    #endregion

    #region CTOR
    public AlcoholComposite()
    {
      BeerComposites = new Collection<BeerComposite>();
      WineComposites = new Collection<WineComposite>();
      WhiskeyComposites = new Collection<WhiskeyComposite>();
      VodkaComposites = new Collection<VodkaComposite>();
      loadBeer();
      loadVodka();
    }
    #endregion

    #region Methods
    public void AddAlcohol(Alcohols alcohol)
    {
      if (alcohol.GetType() == typeof(Beer))
      {

        var b = BeerComposites.Where(x => x.Type == alcohol.Type).FirstOrDefault();
        if (b == null)
          BeerComposites.Add(new BeerComposite((Beer)alcohol));
        else
          b.AddAlcohol((Beer)alcohol);
      }
      else if (alcohol.GetType() == typeof(Vodka))
      {
        var v = VodkaComposites.Where(x => x.Type == alcohol.Type).FirstOrDefault();
        if (v == null)
          VodkaComposites.Add(new VodkaComposite((Vodka)alcohol));
        else
          v.AddAlcohol((Vodka)alcohol);
      }
    }

    public Alcohols GetAlcohol(string name)
    {
      foreach (BeerComposite bc in BeerComposites)
      {
        if (bc.CheckForBeer(name))
        {
          return bc.GetAlcohol(name);
        }
      }

      foreach(VodkaComposite vc in VodkaComposites)
      {
        if (vc.CheckForAlcohol(name))
        {
          return vc.GetAlcohol(name);
        }
      }

      return null;
    }

    public String UpVote(string name)
    {
      foreach (BeerComposite bc in BeerComposites)
      {
        if (bc.CheckForBeer(name))
        {
          bc.UpVote(name);
          return "Successful";
        }
      }
      return "Unsuccessful";
    }

    public String DownVote(string name)
    {
      foreach (BeerComposite bc in BeerComposites)
      {
        if (bc.CheckForBeer(name))
        {
          bc.DownVote(name);
          return "Successful";
        }
      }
      return "Unsccessful";
    }


    public string GetVotes(string name)
    {
      foreach (BeerComposite bc in BeerComposites)
      {
        if (bc.CheckForBeer(name))
        {

          return bc.GetVotes(name); ;
        }
      }
      return "Unsccessful";
    }

    public Collection<Alcohols> GetAllAlcohols()
    {
      Collection<Alcohols> alcohols = new Collection<Alcohols>();
      foreach (BeerComposite bc in BeerComposites)
      {
        alcohols.Concat(bc.GetAllAlcohols());
      }
      return alcohols;
    }
    #endregion

    #region ForTesting
    public void loadBeer()
    {
      Collection<Beer> tmp = new Collection<Beer>();
      tmp.Add(new Beer("American IPA", "India Pale Ales", 4.5));
      tmp.Add(new Beer("EnglishIPA", "India Pale Ales", 4.5));
      tmp.Add(new Beer("Imperial IPA", "India Pale Ales", 4.5));
      tmp.Add(new Beer("New England American IPA", "India Pale Ales", 6));
      tmp.Add(new Beer("West Coast IPA", "India Pale Ales", 5));
      tmp.Add(new Beer("American pilsner", "Pilsner", 5));
      tmp.Add(new Beer("Czech pilsner", "Pilsner", 5));
      tmp.Add(new Beer("German pilsner", "Pilsner", 5));
      tmp.Add(new Beer("American stout", "Stout", 5));
      tmp.Add(new Beer("American imperial stout", "Stout", 5));
      tmp.Add(new Beer("Irish dry stout", "Stout", 5));
      tmp.Add(new Beer("Milk stout", "Stout", 5));
      tmp.Add(new Beer("Oatmeal stout", "Stout", 5));
      tmp.Add(new Beer("Oyster stout", "Stout", 5));

      foreach (var temp in tmp)
      {
        AddAlcohol(temp);
      }
    }

    public void loadVodka()
    {
      Collection<Vodka> vod = new Collection<Vodka>();
      vod.Add(new Vodka("Woody Creek", "Potato", 40));
      vod.Add(new Vodka("Monopolowa", "Potato", 42));
      vod.Add(new Vodka("Chase", "Potato", 42));
      vod.Add(new Vodka("Grey Goose", "Grain", 39));
      vod.Add(new Vodka("Smirnoff", "Grain", 39));
      vod.Add(new Vodka("Stolichnaya", "Grain", 39));
      vod.Add(new Vodka("Absolu tLime", "Fruit", 39));
      vod.Add(new Vodka("Three Olives Rosé Vodka", "Fruit", 39));
      vod.Add(new Vodka("Hangar 1 Rosé Vodka", "Fruit", 39));

      foreach (var temp in vod)
      {
        AddAlcohol(temp);
      }
    }
    #endregion
  }
}
