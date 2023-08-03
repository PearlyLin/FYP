using System;
using Microsoft.AspNetCore.Mvc;
namespace FYPfinalWEBAPP.Controllers
{
  public class HomeController : Controller
  {
//    public String Index() => "FYPfinalWEBAPP Home";
      public IActionResult Index()
        {
            return View();
        }
  }
}

