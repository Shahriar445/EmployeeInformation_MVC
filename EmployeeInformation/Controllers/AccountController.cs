using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeInformation.Controllers
{

    
    public class AccountController : Controller
    {
        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(string username, string password)
        {
            if (username=="admin" && password=="admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username)
                };

                var claimsIdentity =new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);


                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Employee");
            }

            ViewBag.ErrorMessage = "Invalide User Name & Password";
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login","Account");  
        }
    }
}
