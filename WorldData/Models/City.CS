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


    public override bool Equals(System.Object otherCity)
    {
      if (!(otherCity is City))
      {
      return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool idEquality = (this.GetId() == newCity.GetId());
        bool nameEquality = (this.GetName() == newCity.GetName());
        bool districtEquality = (this.GetDistrict() == newCity.GetDistrict());
        bool popEquality = (this.GetPopulation() == newCity.GetPopulation());

        return (idEquality && nameEquality && districtEquality && popEquality);
      }
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
      cmd.CommandText = @"SELECT * FROM city WHERE ID < 60;";
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;

      //_id
      cmd.CommandText = @"INSERT INTO 'city' ('id')
      VALUES (@cityId);";

      MySqlParameter id = new MySqlParameter();
      id.ParameterName = "@cityId";
      id.Value = this._id;
      cmd.Parameters.Add(id);

      //_name
      cmd.CommandText = @"INSERT INTO 'city' ('name')
      VALUES (@cityName);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@cityName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      //_district
      cmd.CommandText = @"INSERT INTO 'city' ('district')
      VALUES (@cityDistrict);";

      MySqlParameter district = new MySqlParameter();
      district.ParameterName = "@cityDistrict";
      district.Value = this._district;
      cmd.Parameters.Add(district);

      //_population
      cmd.CommandText = @"INSERT INTO 'city' ('population')
      VALUES (@cityPopulation);";

      MySqlParameter population = new MySqlParameter();
      population.ParameterName = "@cityPopulation";
      population.Value = this._population;
      cmd.Parameters.Add(population);


      cmd.ExecuteNonQuery();

      //more logic

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

  }//end class

}//end namespace
