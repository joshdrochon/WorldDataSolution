using WorldDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WorldDataProject.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("WorldData/AllCities")]
    public ActionResult AllCities()
    {
      return View("../WorldData/AllCities");
    }

    [HttpGet("WorldData/CreateCityForm")]
    public ActionResult CreateCityForm()
    {
      return View("WorldData/CreateCityForm");
    }
  }
}
