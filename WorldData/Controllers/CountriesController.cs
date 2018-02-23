using WorldDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WorldDataProject.Controllers
{
  public class CountriesController : Controller
  {
    [HttpGet("WorldData/AllCountries")]
    public ActionResult AllCountries()
    {
      return View("../WorldData/AllCountries");
    }

    [HttpGet("CreateCountryForm")]
    public ActionResult CreateCountryForm()
    {
      return View("WorldData/CreateCountryForm");
    }
  }
}
