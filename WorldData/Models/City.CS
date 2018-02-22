using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldDataProject;
using System;

namespace WorldDataProject.Models
{
  public class City
  {
    private int _id; //index 0 - int
    private string _name; //index 1 - char
    private string _district; //index 3 -char
    private int _population;//index 4 -int

    public City(int Id, string Name, string District, int Population)
    {
      _id = Id;
      _name = Name;
      _district = District;
      _population = Population;
    }

    //_id getter/setter
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
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

    //_district getter/setter
    public string GetDistrict()
    {
      return _district;
    }
    public void SetDistrict(string newDistrict)
    {
      _district = newDistrict;
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

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityId, cityName, cityDistrict, cityPopulation);
        allCities.Add(newCity);
      }

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM city;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

  }//end class

}//end namespace
