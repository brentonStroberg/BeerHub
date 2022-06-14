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

    AlcoholComposite ac = new AlcoholComposite();

    public Main()
    {

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


    #endregion
  }
}
