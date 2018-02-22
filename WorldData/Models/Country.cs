using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDataProject;
using System;

namespace WorldDataProject.Models
{
  public class Country
  {
    private string _code; //[0]
    private string _name; //[1]
    private string _continent; //[2]
    private int _population; //[6]

    public Country(string Code, string Name, string Continent, int Population)
    {
      _code = Code;
      _name = Name;
      _continent = Continent;
      _population = Population;
    }

    //_code getter/setter
    public string GetCode()
    {
      return _code;
    }
    public void SetCode(string newCode)
    {
      _code = newCode;
    }

    //_name getter/setter
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    //_continent getter/setter
    public string GetContinent()
    {
      return _continent;
    }
    public void SetContinent(string newContinent)
    {
      _continent = newContinent;
    }


    //_population getter/setter
    public int GetPopulation()
    {
      return _population;
    }
    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }


    public static List<Country> GetAll() /*returns a List which contains Country objects*/
    {
        List<Country> allCountries = new List<Country>();
        MySqlConnection conn = DB.Connection(); //MySqlConnection represents database, calling DB.Connection establishes a connection w/ mysql database
        conn.Open(); //opens the connection
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string countryCode = rdr.GetString(0);
          string countryName = rdr.GetString(1);
          string countryCont = rdr.GetString(2);
          int countryPop = rdr.GetInt32(6);
          Country newCountry = new Country(countryCode, countryName, countryCont, countryPop);
          allCountries.Add(newCountry);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCountries;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM country;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
