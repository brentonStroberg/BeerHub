using BeerHub.Controllers;
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

    public void loadAlcohol()
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
            //Alcohols a = new Alcohols((string)reader["Name"], (string)reader["Type"], (string)reader["SpecificType"], (double)reader["Percentage"], (int)reader["AlcoholId"], (int)reader["Calories"], (int)reader["Downvote"], (int)reader["Upvote"]);
            //public Alcohols(string name, string type, string specificType, double percentage, int id, int downvote, int upvote)
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

  }
}
