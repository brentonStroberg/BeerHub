using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerHub.Interfaces
{
  public class Alcohol
  {
    #region Privates
    private string name;
    private double percentage;
    private string type;
    private int id;
    private int downvote;
    private int upvote;
    #endregion

    #region Properties
    public string Name
    {
      get { return name; }
      set
      {
        if (name != value)
        {
          name = value;
        }
      }
    }

    public double Percentage
    {
      get { return percentage; }
      set
      {
        if (percentage != value)
        {
          percentage = value;
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




    public int ID
    {
      get { return id; }
      set
      {
        if (id != value)
        {
          id = value;
        }
      }
    }

    public int Upvote
    {
      get { return upvote; }
      set
      {
        if (upvote != value)
        {
          upvote = value;
        }
      }
    }

    public int Downvote
    {
      get { return downvote; }
      set
      {
        if (downvote != value)
        {
          downvote = value;
        }
      }
    }

    #endregion

    #region CTOR
    public Alcohol()
    {
    }
    public Alcohol(string name, string type, double percentage)
    {
      this.name = name;
      this.percentage = percentage;
      this.type = type;
      this.downvote = 0;
      this.upvote = 0;
    }
    public Alcohol(string name, double percentage, string type, int id, int downvote, int upvote)
    {
      this.name = name;
      this.percentage = percentage;
      this.type = type;
      this.id = id;
      this.downvote = downvote;
      this.upvote = upvote;
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
