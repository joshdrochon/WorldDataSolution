using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorldDataProject.Models;
using WorldDataProject;

namespace WorldDataProject.Tests
{
  [TestClass]
  public class CountryTests : IDisposable
  {
    public void Dispose()
    {
      Country.DeleteAll();
    }

    public CountryTests()
    {
      DBConfiguration.ConnectionString =
      "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }


    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Country.GetAll().Count;
      //Assert
      Assert.AreEqual(0, result);
    }


  }
}
