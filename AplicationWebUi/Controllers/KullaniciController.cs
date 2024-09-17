using AplicationWebUi.Helpers;
using AplicationWebUi.Models;
using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AplicationWebUi.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        private readonly IUserService _userService; 
        private readonly IHasher _hasher;

        public KullaniciController(IUserService userService, IHasher hasher)
        {
            _userService = userService;
            _hasher = hasher;
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
                    if (user.Password == _hasher.DoMd5HashedString(model.Password))
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()));
                        claims.Add(new Claim("Username",user.Username));
                        claims.Add(new Claim("ProfilFoto",user.ProfileImageFileName));
                        claims.Add(new Claim(ClaimTypes.Name,user.Fullname));
                        claims.Add(new Claim(ClaimTypes.Role,user.Role));
                        
                        ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                       
                        return RedirectToAction("KullaniciGiris", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Şifre veya kullanıcı adı hatalı");
                    }
                }
                

            }


            return View(model);
        }
        private void ProfilFotoGET(int id)
        {

        }
        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            
            return View();
        }
        [Authorize(Roles = "admin")]
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
                        Password = _hasher.DoMd5HashedString(model.Password),
                        Email = model.email,
                        Role = model.Role
                    };
                    _userService.Create(user);
                    ViewData["result"] = "Basarili";
                    ViewData["message"] = "Kişi Başarılı bir şekilde Kayıt edildi";
                    
                    
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
   
        public IActionResult Profile() {

            ProfileinfoLoader();
            return View();
        }
        private void ProfileinfoLoader()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _userService.GetById(userid);
            ViewData["Fullname"]=user.Fullname;
            ViewData["Username"] = user.Username;
            ViewData["Profileİmage"] = user.ProfileImageFileName;

        }

        public IActionResult ProfileChangeImage([Required] IFormFile file)
        {
            if (ModelState.IsValid) { 
            
                int userid= int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _userService.GetById(userid);
                string folderpath = Path.Combine($"wwwroot/Uploads", user.ProfileImageFileName);
                if (System.IO.File.Exists(folderpath)) {
                    System.IO.File.Delete(folderpath);
                }
                var ex=Path.GetFileName(file.FileName);
                string fileName = $"p_{user.UserId}{ex}";
              
                Stream stream = new FileStream($"wwwroot/Uploads/{fileName}",FileMode.OpenOrCreate);
                file.CopyTo(stream);
                
                stream.Close();
                stream.Dispose();           
                user.ProfileImageFileName = fileName;
                _userService.Update(user);
                return RedirectToAction(nameof(Profile));
            
            }


            return View();
        }

        [HttpPost]
        public IActionResult ProfileChangeFullname([Required][StringLength(25, ErrorMessage = "En fazla 25 karakter olmalı")] [MinLength(4,ErrorMessage ="EN az 4 karakterli olmalı")] string Fullname)
        {
            if (ModelState.IsValid)
            {

                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _userService.GetById(userid);
                user.Fullname = Fullname;
                _userService.Update(user);
                return RedirectToAction(nameof(Profile));

            }


            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        public IActionResult ProfileChangeUsername([Required][StringLength(25, ErrorMessage = "En fazla 25 karakter olmalı")][MinLength(4, ErrorMessage = "EN az 4 karakterli olmalı")] string Username)
        {
            if (ModelState.IsValid)
            {

                int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _userService.GetById(userid);
                user.Username = Username;
                _userService.Update(user);
                return RedirectToAction(nameof(Profile));

            }


            return View();
        }
        [HttpPost]
        public IActionResult ProfileChangePassword(
            [Required]
            [MinLength(4, ErrorMessage = "En az 4 karakterden oluşmalı şifreniz")] string Password, string RePassword)
        {
            
            if (ModelState.IsValid)
            {
                if(Password == RePassword)
                {
                    int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    User user = _userService.GetById(userid);
                    user.Password =_hasher.DoMd5HashedString(Password);
                    _userService.Update(user);
                    return RedirectToAction(nameof(Profile));
                }
                else
                {
                    ModelState.AddModelError("", "Şifre değiştirlmedi lütfen şifreyi tekrar girin");
                }            

            }
            return RedirectToAction(nameof(Profile));
        }



    }
}
