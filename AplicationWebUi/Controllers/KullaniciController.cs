using Microsoft.AspNetCore.Mvc;

namespace AplicationWebUi.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Login()
        {
            return PartialView();
        }
     
    }
}
