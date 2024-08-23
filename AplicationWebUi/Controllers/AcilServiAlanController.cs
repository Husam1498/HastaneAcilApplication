using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWebUi.Controllers
{
    public class AcilServiAlanController : Controller
    {
        private IAcilServisAlanService _service;

        public AcilServiAlanController(IAcilServisAlanService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AcilServisAlan entity)
        {
            _service.Create(entity);
            return RedirectToAction(nameof(List));
        }
        public IActionResult List()
        {
            return View(_service.GetAll());
        }
    }
}
