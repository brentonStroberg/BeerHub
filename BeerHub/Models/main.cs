using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class main
  {

    AlcoholComposite ac = new AlcoholComposite();

    public main()
    {

    }

    #region Gets
    public Alcohol GetBeer(string name)
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

    #endregion
  }
}
