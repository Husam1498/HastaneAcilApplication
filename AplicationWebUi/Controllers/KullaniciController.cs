using AplicationWebUi.Models;
using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AplicationWebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class KullaniciController : Controller
    {
        private IUserService _userService; 

        public KullaniciController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
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
                        claims.Add(new Claim(ClaimTypes.Role,user.Role));

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
                User u = _userService.GetByUsername(model.Username);
                if (u == null)
                {
                    User user = new User
                    {
                        Fullname = model.Fullname,
                        Username = model.Username,
                        Password = model.Password,
                        Email = model.email,
                        Role = model.Role
                    };
                    _userService.Create(user);

                    return RedirectToAction("AnaSayfa", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Username", "Kullanıcı adı var lütfen giriş yapınız");
                }
               
            }



            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Logout() {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete(int id) {
           var user= _userService.GetById(id);
            if (user != null)
            {
                _userService.Delete(user);
                return RedirectToAction("AnaSayfa", "Admin");
            }
            else
            {
                //Kişi Silinemedi
            }
            
            return View();
        }



        public IActionResult KullaniciList() {
            return View(_userService.GetAll());
       
        } 
        public IActionResult KullaniciUpdate(int id) {
            var user=_userService.GetById(id);
            UpdateUserMode m = new UpdateUserMode { 
                UserId=user.UserId,
                Username=user.Username,
               
                email=user.Email,
                Fullname=user.Fullname,
                Role=user.Role,

            }
            ;

            return View(m);
        }

        [HttpPost]
        public IActionResult KullaniciUpdate(int id,UpdateUserMode model)
        {
            if (ModelState.IsValid) {
                var u=_userService.GetById(id);
                if (u != null) {
                    u.Email = model.email;
                    u.Fullname = model.Fullname;
                    u.Role = model.Role;
                    u.Username = model.Username;
                    _userService.Update(u);
                    return RedirectToAction("AnaSayfa", "Admin");

                }
            
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
