using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDataProject;
using System;

namespace WorldDataProject.Models
{
  public class Country
  {
    private static List<Country> allCountries; //getAll method will return this list
    private string _code; //index 0
    private string _name; //index 1
    private string _continent; //index 2
    private int _population; //index 6

    public Country(string Code, string Name, string Continent, int Population)
    {
      _code = Code;
      _name = Name;
      _continent = Continent;
      _population = Population;
    }

    //code setter/getter
    public void SetCode(string newCode)
    {
      _code = newCode;
    }
    public string GetCode()
    {
      return _code;
    }
    //name setter/getter
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetName()
    {
      return _name;
    }

    //continent setter/getter
    public void SetContinent(string newContinent)
    {
      _continent = newContinent;
    }
    public string GetContinent()
    {
      return _continent;
    }

    //population setter/getter
    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }
    public int GetPopulation()
    {
      return _population;
    }

        public static List<Country> GetAll() /*returns a List which contains Country objects*/
        {
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
          allCountries.Clear();
        }
  }
}
