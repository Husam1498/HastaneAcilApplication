using AplicationWebUi.Models;
using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AplicationWebUi.Controllers
{
    public class KullaniciController : Controller
    {
        private IUserService _userService;

        public KullaniciController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user=_userService.GetByUsername(model.Username);
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()));
                        claims.Add(new Claim("Username",user.Username));
                        claims.Add(new Claim(ClaimTypes.Name,user.Fullname));

                        ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);


                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Şifre veya kullanıcı adı hatalı");
                    }
                }
                

            }


            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                User user = new User
                {
                    Fullname = model.Fullname,
                    Username=model.Username,
                    Password = model.Password,
                    Email=model.email
                };
                _userService.Create(user);

                return RedirectToAction(nameof(Login));
            }



            return View(model);
        }

        public IActionResult Logout() {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");


        }
    }
}
