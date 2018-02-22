using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorldDataProject.Models;
using WorldDataProject;
using System;

namespace WorldDataProject.Tests
{
  [TestClass]
  public class CityTests : IDisposable
  {
    public void Dispose()
    {
      City.DeleteAll();
    }

    public CityTests()
    {
      DBConfiguration.ConnectionString =
      "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = City.GetAll().Count;
      Console.WriteLine("Line 28: " + result);

      //Assert
      Assert.AreEqual(0, result);
    }

    //adds city
    // int testCityId = 0;
    // string testCityName = null;
    // string testCityDist = null;
    // int testCityPop = 0;
    // City testCity = new City
    // (testCityId, testCityName, testCityDist, testCityPop);
    // int actualResult = City.GetAll().Count;
    // Console.WriteLine("LINE 29 " + actualResult);
  }
}
