using System;
using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ispit_2017_02_15.Services;
using Ispit_2017_02_15.Interfaces;
using System.Linq;
using Ispit_2017_02_15.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ispit_2017_02_15.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MojContext _context;
        private IHttpContextAccessor _httpContext;

        private IOdjeljenjeServices _odjeljenje;
        public OdjeljenjeController(IOdjeljenjeServices odjeljenje, MojContext db, IHttpContextAccessor httpContext)
        {
            _odjeljenje = odjeljenje;
            _context = db;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            int nastavnikId = 2;
            return View(_odjeljenje.OdrzaniCasoviTabela(nastavnikId));
        }

        [HttpPost]
        public IActionResult DodajNoviCas(NoviCasViewModel cas)
        {
            _odjeljenje.DodajNoviCas(cas);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult OdrzanCas(int odrzanCasId)
        {
            int nastavnikId = 2;

            UrediCasViewModel urediCas = _context.OdrzaniCasovi
                .Include(oc => oc.Angazovan)
                .ThenInclude(a => a.AkademskaGodina) 
                .Include(oc => oc.Angazovan)
                .ThenInclude(a => a.Nastavnik) 
                .Where(oc => oc.Id == odrzanCasId && oc.Angazovan.NastavnikId == nastavnikId)
                .Select(oc => new UrediCasViewModel
                {
                    AkGodinaPredmet = oc.Angazovan.AkademskaGodina.Opis,
                    Datum = oc.Datum,
                    ImePrezimeNastavnika = oc.Angazovan.Nastavnik.Ime[0] + ". " + oc.Angazovan.Nastavnik.Prezime + ".",
                    OdrzanCasId = oc.Id
                }).FirstOrDefault();

            return View(urediCas);
        }


        [HttpPost]
        public IActionResult UrediOdrzanCas(UrediCasViewModel cas)
        {
            int nastavnikId = 2;

            OdrzaniCas odrzaniCas = _context.OdrzaniCasovi
                .Include(oc => oc.Angazovan)
                .ThenInclude(a => a.AkademskaGodina)
                .Include(oc => oc.Angazovan)
                .ThenInclude(a => a.Nastavnik)
                .Where(oc => oc.Id == cas.OdrzanCasId && oc.Angazovan.NastavnikId == nastavnikId)
                .FirstOrDefault();

            odrzaniCas.Datum = cas.Datum;
            _context.OdrzaniCasovi.Update(odrzaniCas);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OdrzaniCasDetalji(int odrzanCasId)
        {
            int nastavnikId = 2;

            HashSet<OdrzaniCasDetaljiTabelaViewModel> odrzaniCasDetalji = _context.OdrzaniCasDetalji
                .Include(ocd => ocd.SlusaPredmet)
                .Where(ocd => ocd.OdrzaniCasId == odrzanCasId)
                .Select(ocd => new OdrzaniCasDetaljiTabelaViewModel
                {
                    OdrzaniCasDetaljiId = ocd.Id,
                    Bodovi = ocd.BodoviNaCasu,
                    Prisutan = ocd.Prisutan,
                    ImeStuenta = ocd.SlusaPredmet.UpisGodine.Student.Ime,
                    PrezimeStuenta = ocd.SlusaPredmet.UpisGodine.Student.Prezime
                }).ToHashSet();

            return View(odrzaniCasDetalji);
        }


        [HttpGet]
        public IActionResult OdrzaniCasDetalj(int odrzaniCasDetaljiId)
        {
            int nastavnikId = 2;

            OdrzaniCasDetaljViewModel odrzaniCasDetalji =
                _context.OdrzaniCasDetalji
                    .Where(ocd => ocd.Id == odrzaniCasDetaljiId)
                    .Select(ocd => new OdrzaniCasDetaljViewModel
                    {
                        OdrzaniCasDetaljiId = ocd.Id,
                        Bodovi = ocd.BodoviNaCasu,
                        ImeStudenta = ocd.SlusaPredmet.UpisGodine.Student.Ime,
                        PrezimeStudenta = ocd.SlusaPredmet.UpisGodine.Student.Prezime,
                    }).First();
                    

            return Ok(odrzaniCasDetalji);
        }
        [HttpPost]
        public IActionResult UpdateOdrzaniCasDetalj(int odrzaniCasDetaljiId, int bodovi)
        {
            //treba provjeriti možda da li korisnik koji je logiran aažurira podatke koje smije ažurirati
            OdrzaniCasDetalji odrzaniCasDetalji = _context.OdrzaniCasDetalji
                .Find(odrzaniCasDetaljiId);

            odrzaniCasDetalji.BodoviNaCasu = bodovi;

            _context.OdrzaniCasDetalji.Update(odrzaniCasDetalji);
            _context.SaveChanges();

            return View("OdrzaniCasDetalji", _odjeljenje.OdrzaniCasDetalji(odrzaniCasDetalji.OdrzaniCasId));
        }

        [HttpPost]
        public IActionResult UpdatePrisustvoOdrzaniCasDetalj(int odrzaniCasDetaljiId, bool prisutan)
        {
            //treba provjeriti možda da li korisnik koji je logiran aažurira podatke koje smije ažurirati
            OdrzaniCasDetalji odrzaniCasDetalji = _context.OdrzaniCasDetalji
                .Find(odrzaniCasDetaljiId);

            odrzaniCasDetalji.Prisutan = prisutan;

            _context.OdrzaniCasDetalji.Update(odrzaniCasDetalji);
            _context.SaveChanges();

            return View("OdrzaniCasDetalji", _odjeljenje.OdrzaniCasDetalji(odrzaniCasDetalji.OdrzaniCasId));
        }


    }
}