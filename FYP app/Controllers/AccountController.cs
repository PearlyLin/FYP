using FYPfinalWEBAPP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RP.SOI.DotNet.Utils;
using System.Data;
using System.Security.Claims;


namespace FYPfinalWEBAPP.Controllers;

public class AccountController : Controller
{
    [Authorize]
    public IActionResult Logoff(string returnUrl = null!)
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        return RedirectToAction("Index", "Listing");
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null!)
    {
        TempData["ReturnUrl"] = returnUrl;
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(UserLogin user)
    {
        if (!AuthenticateUser(user.UserID, user.Password,
                              out ClaimsPrincipal principal))
        {
            ViewData["Message"] = "Incorrect User ID or Password";
            return View();
        }
        else
        {
            HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               principal);

            if (TempData["returnUrl"] != null)
            {
                string returnUrl = TempData["returnUrl"]!.ToString()!;
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Listing");
        }
    }

    private static bool AuthenticateUser(string uid, string pw,
                                  out ClaimsPrincipal principal)
    {
        principal = null!;
        
        string sql = @"SELECT * FROM TravelUser WHERE UserId = '{0}'
                       AND UserPw = HASHBYTES('SHA1','{1}')";
        string select = string.Format(sql, uid, pw);
        DataTable ds = DBUtl.GetTable(select);
        if (ds.Rows.Count == 1)
        {
            principal =
               new ClaimsPrincipal(
                  new ClaimsIdentity(
                     new Claim[] {
                     new Claim(ClaimTypes.NameIdentifier, uid),
                     new Claim(ClaimTypes.Name, ds.Rows[0]["FullName"].ToString()!)
                     },
                     CookieAuthenticationDefaults.AuthenticationScheme));
            return true;
        }
        return false;
    }
}

