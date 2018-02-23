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

  }
}
