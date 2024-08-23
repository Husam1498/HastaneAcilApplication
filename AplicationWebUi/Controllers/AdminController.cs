using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWebUi.Controllers
{
   
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
