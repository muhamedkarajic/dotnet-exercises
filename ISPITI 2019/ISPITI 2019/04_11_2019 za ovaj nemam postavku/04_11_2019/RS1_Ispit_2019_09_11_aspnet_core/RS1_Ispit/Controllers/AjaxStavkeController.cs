using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxStavkeController : Controller
    {

        private MojContext _db;
        public AjaxStavkeController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            
            PopravniIspit pi = _db.PopravniIspit.Find(id);
        
            AjaxStavkeIndexVM model = new AjaxStavkeIndexVM
            {
                PopravniIspitId = pi.PopravniIspitId,
                Ucenici = _db.PopravniIspitUcenik.Where(y => y.PopravniIspitId == pi.PopravniIspitId).Select(y => new AjaxStavkeIndexVM.Row
                {
                    PopravniIspitUcenikId= y.PopravniIspitUcenikId,
                    Ucenik= y.OdjeljenjeStavka.Ucenik.ImePrezime,
                    BrojUDnevniku= y.OdjeljenjeStavka.BrojUDnevniku,
                    Pristupio= y.Pristupio,
                    Rezultat= y.Rezultlat,
                    Odjeljenje= y.OdjeljenjeStavka.Odjeljenje.Oznaka
                }
                ).ToList()
            };

            return PartialView(model);
        }

        public IActionResult UcenikJePrisutan(int id)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Find(id);
            pi.Pristupio = true;
            _db.SaveChanges();
            return Redirect("/AjaxStavke/Index/" + pi.PopravniIspitId);
        }
        public IActionResult UcenikJeOdsutan(int id)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Find(id);
            pi.Pristupio = false;
            _db.SaveChanges();
            return Redirect("/AjaxStavke/Index/" + pi.PopravniIspitId);
        }
        public IActionResult Uredi(int id)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitUcenikId == id).Include(x => x.OdjeljenjeStavka.Ucenik).FirstOrDefault();
            return PartialView(pi);
        }
        public IActionResult SnimiUredi(PopravniIspitUcenik model)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitUcenikId == model.PopravniIspitUcenikId).Include(x => x.OdjeljenjeStavka.Ucenik).FirstOrDefault();
            pi.Rezultlat = model.Rezultlat;
            _db.SaveChanges();

            return Redirect("/AjaxStavke/Index/" + pi.PopravniIspitId);
        }
    }
}