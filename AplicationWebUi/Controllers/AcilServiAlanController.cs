using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWebUi.Controllers
{
    [Authorize]
    public class AcilServiAlanController : Controller
    {
        private IAcilServisAlanService _service;

        public AcilServiAlanController(IAcilServisAlanService service)
        {
            _service = service;
        }
      
        public IActionResult AcilServisIndex()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(AcilServisAlan entity)
        {
            _service.Create(entity);
            return RedirectToAction(nameof(AcilServisIndex));
        }
        [AllowAnonymous]     
        public IActionResult MemberlistALan()
        {
            return PartialView("_MemberListAlanPartial",_service.GetAll());
        }
        [Authorize(Roles = "admin")]
        public IActionResult UpdateAlan(int id)
        {
            var entity=_service.GetById(id);
            return View(entity);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult UpdateAlan(AcilServisAlan entity)
        {
            _service.Update(entity);
            return RedirectToAction(nameof(AcilServisIndex));
        }
        [Authorize(Roles = "admin")]
        public IActionResult DeleteAlan(int id)
        {
            var alan= _service.GetById(id);
            _service.Delete(alan);
            return RedirectToAction(nameof(AcilServisIndex));
        }


    }
}
