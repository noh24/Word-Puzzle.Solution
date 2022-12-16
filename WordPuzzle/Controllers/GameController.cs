using Microsoft.AspNetCore.Mvc;
using System; 
using System.Collections.Generic;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GameController: Controller
  {
    [HttpGet("/game")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/game/create")]
    public ActionResult Create()
    {
      Game newGame = new Game();
      return View("Index", newGame);
    }
    [HttpPost("/game")]
    public ActionResult Create(char guess)
    {
      Game.MyGame.Guess(guess);
      return View("Index", Game.MyGame);
    }
  }
}