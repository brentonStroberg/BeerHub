﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerHub.Interfaces
{
<<<<<<<< HEAD:BeerHub/Models/Booze.cs
  public class Booze
========
  public class Alcohols
>>>>>>>> main:BeerHub/Interfaces/Alcohols.cs
  {
    #region Privates
    public string Name { get; set; }
    public double Percentage { get; set; }
    public string Type { get; set; }
    public int ID { get; set; }
    public int Downvote { get; set; }
    public int Upvote { get; set; }
<<<<<<<< HEAD:BeerHub/Models/Booze.cs

    public string SpecificType { get; set; }

    public Booze(string specificType)
    {
      SpecificType = specificType;
    }
========
    public int Calories { get; set; }
    public string SpecificType { get; set; }
>>>>>>>> main:BeerHub/Interfaces/Alcohols.cs
    #endregion

    #region CTOR
<<<<<<<< HEAD:BeerHub/Models/Booze.cs
    public Booze()
    {
    }
    public Booze(string name, string type, string specificType, double percentage)
========
    public Alcohols()
    {
    }
    public Alcohols(string name, string type, double percentage)
>>>>>>>> main:BeerHub/Interfaces/Alcohols.cs
    {
      this.Name = name;
      this.Percentage = percentage;
      this.Type = type;
      this.ID = -1;
      this.Downvote = 0;
      this.Upvote = 0;
      this.SpecificType = specificType;
    }
<<<<<<<< HEAD:BeerHub/Models/Booze.cs
    public Booze(string name, double percentage, string type, string specificType, int id, int downvote, int upvote)
========
    public Alcohols(string name, double percentage, string type, int id, int downvote, int upvote)
>>>>>>>> main:BeerHub/Interfaces/Alcohols.cs
    {
      this.Name = name;
      this.Percentage = percentage;
      this.Type = type;
      this.ID = id;
      this.Downvote = downvote;
      this.Upvote = upvote;
      this.SpecificType = specificType;
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
