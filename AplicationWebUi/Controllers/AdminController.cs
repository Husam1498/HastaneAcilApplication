﻿using Bussiness.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entity;

namespace AplicationWebUi.Controllers
{
    //[Authorize(Roles ="admin,manager")]//login olmuşolanlar girebilir
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
     
        private IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult AnaSayfa() 
        {
           
            return View();
        }
        public IActionResult UserListPartial()
        {
        
            return PartialView("_UserListPartial", _userService.GetAll());
        }
    }
}
