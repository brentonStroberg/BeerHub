﻿using BeerHub.Controllers;
using BeerHub.Database;
using BeerHub.Interfaces;
using BeerHub.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Main
  {
    private AlcoholMapper map;
    private AlcoholMainCollection amc;
    private CocktailsComposite cc;

    public Main()
    {
      map = new AlcoholMapper();
      amc = new AlcoholMainCollection();
      cc = new CocktailsComposite();
      loadAlcohol();
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
      bool temp = amc.RemoveAlcohol(name);
      if (temp)
      {
        RemoveAlcohols(name);
      }
      return temp;
    }

    public bool AddAlcohol(Alcohols alcohol)
    {
      return amc.AddAlcohol(alcohol);
    }

    public void Save()
    {
      foreach (var l in GetAllAlcohols())
      {
        Save(l);
      }
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

    public void loadAlcohol()
    {
      string queryString = "SELECT * from Alcohol";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            amc.AddAlcohol(new Alcohols((string)reader["Name"], (string)reader["Type"], (string)reader["SpecificType"], (double)reader["Percentage"], (int)reader["AlcoholId"], (int)reader["Calories"], (int)reader["Downvote"], (int)reader["Upvote"]));
          }
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }

    public void Save(Alcohols alc)
    {
      string query = "MERGE INTO Alcohol a USING( " +
        " VALUES (" + alc.ID + ",'" + alc.Name + "', '" + alc.Type + "','" + alc.SpecificType + "', " + alc.Percentage + ", " + alc.Calories + ", " + alc.Downvote + " , " + alc.Upvote + ") )" +
        " AS m(AlcoholId, Name, Type, SpecificType, Percentage, Calories, Downvote, Upvote )" +
        " ON a.AlcoholId = m.AlcoholId" +
        " WHEN MATCHED THEN" +
        " UPDATE SET a.Name = m.Name, a.SpecificType=m.SpecificType, a.Percentage=m.Percentage, a.Calories=m.Calories, a.Downvote=m.Downvote, a.Upvote=m.Upvote" +
        " " +
        " WHEN NOT MATCHED THEN" +
        " INSERT( Name, Type, SpecificType, Percentage, Calories, Downvote, Upvote )" +
        " VALUES(m.Name, m.Type, m.SpecificType, m.Percentage, m.Calories,  m.Downvote, m.Upvote); ";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }


    public void RemoveAlcohols(string name)
    {
      string queryString = "DELETE FROM Alcohol where Name == @tPatSName";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@tPatSName", name);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }
  }
}

//{
//  var list = AlcoholController._db.alcohol.ToList();
// foreach (var l in list)
//  {
//    amc.AddAlcohol(map.AlcoholDTOToAlcohol(l));
//  }
//}
//public void loadCocktails()
//{
//  Collection<Cocktails> tmp = new Collection<Cocktails>();
//  tmp.Add(new Cocktails("Pisco Punch", new Collection<string> { "pisco", "pineapple", "lemon", "orange", "cloves", "Champagne" }, 10.2));
//  tmp.Add(new Cocktails("Sidecar", new Collection<string> { "brandy", "lemon", "riple sec" }, 10.2));
//  tmp.Add(new Cocktails("Blood & Sand", new Collection<string> { "whisky", "sweet vermouth", "cherry liqueur", "orange juice" }, 10.2));
//  tmp.Add(new Cocktails("Irish Coffee", new Collection<string> { "coffee", " Irish whiskey", "cream" }, 10.2));

//  foreach (var temp in tmp)
//  {
//    cc.AddCocktails(temp);
//  }
//}

//public void loadBeer()
