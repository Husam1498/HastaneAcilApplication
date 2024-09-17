using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace AplicationWebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class DoktorController : Controller
    {
        private IDoktorService _service;
        private IAcilServisAlanService _acilServisAlanService;

        public DoktorController(IDoktorService service, IAcilServisAlanService acilServisAlanService)
        {
            _service = service;
            _acilServisAlanService = acilServisAlanService;
        }
        public IActionResult DoktorIndex()
        {
           
            return View();
        }
        public IActionResult MemberListDoktor()
        {
            Hashtable _alanlar = new Hashtable();
            foreach (var d in _acilServisAlanService.GetAll())
            {
                _alanlar.Add(d.AlanId, d.AlanName);
            }
            ViewBag.Alanlar = _alanlar;
            return PartialView("_ListDoktorPartial", _service.GetAll());
        }
        public IActionResult CreateDoktor()
        {
            ViewBag.Alanname = new SelectList(_acilServisAlanService.GetAll(),"AlanId","AlanName");

            return View();
        }
        [HttpPost]
        public IActionResult CreateDoktor(Doktor entity)
        {
            _service.Create(entity);
            return RedirectToAction(nameof(DoktorIndex));
        }
        [AllowAnonymous]

        public IActionResult UpdateDoktor(int id)
        {
            ViewBag.alanlar = new SelectList(_acilServisAlanService.GetAll(), "AlanId", "AlanName");
            Doktor entity = _service.GetById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult UpdateDoktor(Doktor entity)
        {
           _service.Update(entity);
            return RedirectToAction(nameof(DoktorIndex));
        } 
        public IActionResult DeleteDoktor(int id)
        {
            _service.Delete(_service.GetById(id));
            return RedirectToAction(nameof(DoktorIndex));
        }
    }
}
