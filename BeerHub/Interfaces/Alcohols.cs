using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerHub.Interfaces
{
  public class Alcohols
  {
    #region Privates
    public string Name { get; set; }
    public double Percentage { get; set; }
    public string Type { get; set; }
    public int ID { get; set; }
    public int Downvote { get; set; }
    public int Upvote { get; set; }
    public int Calories { get; set; }
    public string SpecificType { get; set; }
    #endregion

    #region CTOR
    public Alcohols()
    {
    }

    public Alcohols(string name, string type, string specificType, double percentage)
    {
      this.Name = name;
      this.Percentage = percentage;
      this.Type = type;
      this.ID = -1;
      this.Downvote = 0;
      this.Upvote = 0;
      this.SpecificType = specificType;
    }
    public Alcohols(string name, string type, double percentage)
    {
      this.Name = name;
      this.Percentage = percentage;
      this.Type = type;
      this.ID = -1;
      this.Downvote = 0;
      this.Upvote = 0;
    }
    public Alcohols(string name, double percentage, string type, int id, int downvote, int upvote)
    {
      this.Name = name;
      this.Percentage = percentage;
      this.Type = type;
      this.ID = id;
      this.Downvote = downvote;
      this.Upvote = upvote;
    }


    #endregion

    #region Methods
    public virtual double GetRating()
    {
      if (Upvote < Downvote)
      {
        return ((Downvote / Upvote) * 100) * (-1);
      }
      return (Upvote / Downvote) * 100;
    }

    public virtual void UpVote()
    {
      Upvote = Upvote + 1;
    }

    public virtual void DownVote()
    {
      Downvote = Downvote + 1;
    }
    #endregion
  }
}
