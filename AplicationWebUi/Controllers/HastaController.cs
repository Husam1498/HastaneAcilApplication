using AplicationWebUi.Models;
using Bussiness.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace AplicationWebUi.Controllers
{
    [Authorize(Roles = "admin,sekreter")]
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
        public IActionResult CreateHasta(CreateHastaModel model)
        {
            if (ModelState.IsValid)
            {
                Hasta hasta = new()
                {
                    HastaFullname=model.Fullname,
                    DateBirth=model.DateofBirth.ToShortDateString(),
                    HastlıkBilgisi=model.HastallikBikgisi,
                    DoktorId=model.DoktorId,

                };
                hastaService.Create(hasta);
                return RedirectToAction(nameof(HastaIndex));
            }
           
            return View(model);
        }
        public IActionResult UpdateHasta(int id)
        {
            ViewBag.doktorlar = new SelectList(doktorService.GetAll(), "DoktorId", "DoktorFUllname");
            var hasta = hastaService.GetById(id);
            ViewBag.hastabirth=hasta.DateBirth;
            CreateHastaModel a = new()
            {
                HastaId=hasta.HastaId,
                HastallikBikgisi=hasta.HastlıkBilgisi,
                Fullname=hasta.HastaFullname,
                DoktorId=hasta.DoktorId,

            };
            return View(a);
        }
        [HttpPost]
        public IActionResult UpdateHasta(CreateHastaModel model)
        {
            if (ModelState.IsValid) { 
                Hasta hasta=hastaService.GetById(model.HastaId);
                hasta.HastaFullname = model.Fullname;
                hasta.DateBirth=model.DateofBirth.ToShortDateString();
                hasta.DoktorId=model.DoktorId;
                hasta.HastlıkBilgisi=model.HastallikBikgisi;
                hastaService.Update(hasta);

                return RedirectToAction(nameof(HastaIndex));
            }
            return View(model);

        }
        public IActionResult DeleteHasta(int id)
        {
            hastaService.Delete(hastaService.GetById(id));
            return RedirectToAction(nameof(HastaIndex));
        }
       
    }
}
