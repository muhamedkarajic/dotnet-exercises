using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class PopravniIspitController : Controller
    {
        private MojContext _db;
        public PopravniIspitController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            PopravniIspitIndexVM model = new PopravniIspitIndexVM
            {
                Predmeti=_db.Predmet.Select(x=>new PopravniIspitIndexVM.Row
                {
                    PredmetId=x.Id,
                    Predmet= x.Naziv,
                    Razred= x.Razred
                    }).ToList()
            };
            return View(model);
        }
        public IActionResult Prikazi(int id)
        {
            var predmet = _db.Predmet.Where(x => x.Id == id).FirstOrDefault();
            PopravniIspitPrikaziVM model = new PopravniIspitPrikaziVM
            {
                Id = predmet.Id,
                PopravniIspiti = _db.PopravniIspit.Where(x => x.PredmetId == id).Select(x => new PopravniIspitPrikaziVM.Row
                {
                    PopravniIspitId = x.PopravniIspitId,
                    Skola = x.Skola.Naziv,
                    SkolskaGodina = _db.SkolskaGodina.Where(y => y.Aktuelna).Select(y => y.Naziv).FirstOrDefault(),
                    Datum = x.Datum,
                    BrojUcenikaKojiSuPolozili = _db.PopravniIspitUcenik.Where(z => z.PopravniIspitId == x.PopravniIspitId && z.Rezultlat > 5).Count(),
                    BrojUcenikaNaPopravnom= _db.PopravniIspitUcenik.Where(z=>z.PopravniIspitId==x.PopravniIspitId).Count()

                }).ToList()
            };
            return View(model);
        }

        public IActionResult Dodaj(int id)
        {
            var predmet = _db.Predmet.Where(x => x.Id == id).FirstOrDefault();
          
            PopravniIspitDodajVM model = new PopravniIspitDodajVM
            {
                PopravniIspitId=predmet.Id,
                Datum=DateTime.Now,
                Predmet=predmet.Naziv,
                Razred=predmet.Razred,
                Skola= _db.Skola.Select(x=>new SelectListItem
                {
                    Value= x.Id.ToString(),
                    Text= x.Naziv
                }).ToList(),
                SkolskaGodina = _db.SkolskaGodina.Where(x=>x.Aktuelna).Select(x => new SelectListItem
                {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Snimi(PopravniIspitDodajVM model)
        {
            PopravniIspit novi = new PopravniIspit
            {
                PredmetId = model.PopravniIspitId,
                Datum = model.Datum,
                SkolaId= model.SkolaId,
                SkolskGodinaId= model.SkolskaGodinaId
            };

            _db.Add(novi);
            _db.SaveChanges();


            //uslovi

            List<DodjeljenPredmet> ucenici = _db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavka.Odjeljenje.SkolaID == novi.SkolaId &&
             x.OdjeljenjeStavka.Odjeljenje.SkolskaGodinaID == novi.SkolskGodinaId && x.PredmetId == novi.PredmetId && x.ZakljucnoKrajGodine == 1).
            Include(x => x.OdjeljenjeStavka).ToList();

            foreach(var i in ucenici)
            {
                int brojjedinica = _db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == i.OdjeljenjeStavkaId && x.ZakljucnoKrajGodine == 1).Count();

                if(brojjedinica>=3)
                {
                    PopravniIspitUcenik noviucenik= new PopravniIspitUcenik
                    {
                        PopravniIspitId= novi.PopravniIspitId,
                        OdjeljenjeStavkaId= i.OdjeljenjeStavkaId,
                        Pristupio=false,
                        Rezultlat=0
                    };
                    _db.Add(noviucenik);
                }
                else
                {
                    PopravniIspitUcenik noviucenik = new PopravniIspitUcenik
                    {
                        PopravniIspitId = novi.PopravniIspitId,
                        OdjeljenjeStavkaId = i.OdjeljenjeStavkaId,
                        Pristupio = true
                   
                    };
                    _db.Add(noviucenik);
                }
            }

            _db.SaveChanges();
            return Redirect("/PopravniIspit/Prikazi/" + novi.PredmetId);
        }

        public IActionResult Uredi(int id)
        {
            PopravniIspit pi = _db.PopravniIspit.Where(x => x.PopravniIspitId == id).Include(x => x.Predmet).Include(x => x.Skola)
                .Include(x => x.SkolskaGodina).FirstOrDefault();
            PopravniIspitUrediVM model = new PopravniIspitUrediVM
            {
                PopravniIspitId = pi.PopravniIspitId,
                Datum = pi.Datum,
                Predmet = pi.Predmet.Naziv,
                Skola = pi.Skola.Naziv,
                SkolskaGodina = _db.SkolskaGodina.Where(x => x.Aktuelna==true).FirstOrDefault().Naziv,
                Razred= pi.Predmet.Razred
            };

            return View(model);
        }



    }
}