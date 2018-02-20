using WorldDataProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WorldDataProject.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("WorldData/AllCountries")]
    public ActionResult AllCountries()
    {
      return View("../WorldData/AllCountries");
    }
  }
}
