using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWebUi.Controllers
{
    [Authorize(Roles = "admin")]
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
        [AllowAnonymous]
        public IActionResult List()
        {
            return View(_service.GetAll());
        }
        
        public IActionResult UpdateAlan(int id)
        {
            var entity=_service.GetById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult UpdateAlan(AcilServisAlan entity)
        {
            _service.Update(entity);
            return RedirectToAction(nameof(List));
        }
        public IActionResult DeleteAlan(int id)
        {
            var alan= _service.GetById(id);
            _service.Delete(alan);
            return RedirectToAction(nameof(List));
        }


    }
}
