using Microsoft.AspNetCore.Mvc;
using System; 
using System.Collections.Generic;
using WordPuzzle.Models;


namespace WordPuzzle.Controllers
{
  public class HomeController: Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}