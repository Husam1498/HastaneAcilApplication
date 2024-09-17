using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace AplicationWebUi.Controllers
{
    [Authorize(Roles = "admin,sektreter")]
    public class HastaController : Controller
    {
        private IHastaService hastaService;
        private IDoktorService doktorService;

        public HastaController(IHastaService hastaService, IDoktorService doktorService)
        {
            this.hastaService = hastaService;
            this.doktorService = doktorService;
        }
        public IActionResult HastaIndex()
        {
            
            return View();
        }

        public IActionResult MemberListHasta()
        {
            var doktorlarr = doktorService.GetAll();
            Hashtable doktorName = new Hashtable();
            Hashtable doktorServisi = new Hashtable();
            foreach (var d in doktorlarr)
            {

                doktorServisi.Add(d.DoktorId, doktorService.GetDoktorServisName(d.AlanId));//bir dokotrun alan idsi üzerinden alan tablosuna gidip alanid yerine alan namesini koyar

                doktorName.Add(d.DoktorId, d.DoktorFUllname);
            }
            ViewBag.doktorServisiNameGonder = doktorServisi;
            ViewBag.doktorNameGonder = doktorName;

            return PartialView("_ListHastaPartial",hastaService.GetAll());
        }


        public IActionResult CreateHasta()
        {
            ViewBag.doktorlar = new SelectList(doktorService.GetAll(), "DoktorId", "DoktorFUllname");
            return View();
        }
        [HttpPost]
        public IActionResult CreateHasta(Hasta entity)
        {
            hastaService.Create(entity);
            return RedirectToAction(nameof(HastaIndex));
        }
        public IActionResult UpdateHasta(int id)
        {
            ViewBag.doktorlar = new SelectList(doktorService.GetAll(), "DoktorId", "DoktorFUllname");
            return View(hastaService.GetById(id));
        }
        [HttpPost]
        public IActionResult UpdateHasta(Hasta entity)
        {
            hastaService.Update(entity);

            return RedirectToAction(nameof(HastaIndex));
        }
        public IActionResult DeleteHasta(int id)
        {
            hastaService.Delete(hastaService.GetById(id));
            return RedirectToAction(nameof(HastaIndex));
        }
       
    }
}
