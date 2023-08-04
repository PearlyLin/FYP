using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace FYPfinalWEBAPP.Controllers
{
  public class HomeController : Controller
  {
//    public String Index() => "FYPfinalWEBAPP Home";
      public IActionResult Index()
        {
            return View("~/Views/Account/Login.cshtml");
        }
  }
}

