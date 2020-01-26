using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Interfaces;
using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModel;

namespace RS1_Ispit_2017_06_21_v1.Controllers
{
    public class IspitiController : Controller
    {
        private readonly MojContext _context;
        public IIspitiServices _ispitiServices;

        public IspitiController(MojContext db, IIspitiServices ispitiServices)
        {
            _context = db;
            _ispitiServices = ispitiServices;
        }
        public IActionResult Index()
        {
            return View(_ispitiServices.GetMaturskiIspitiTable());
        }


        
        [HttpPost]
        public IActionResult NoviMaturskiIspit(DateTime datum, int odjeljenjeId)
        {
            //nastavnikId se može dobiti na drugi način
            _ispitiServices.NoviMaturskiIspit(datum, odjeljenjeId);

            return RedirectToAction("Index");
        }


        public IActionResult DetaljiMaturskogIspita(int matriskiIspitId)
        {
            //nastavnikId se može dobiti na drugi način
            DetaljiMaturskogIspitaVM dmi = _ispitiServices
                .DetaljiMaturskogIspita(matriskiIspitId);
            return View(dmi);
        }

        public IActionResult RezultatiIspita(int matriskiIspitId)
        {
            //nastavnikId se može dobiti na drugi način
            HashSet<RezultatiIspitaRedVM> ri = _ispitiServices
                .RezultatiIspita(matriskiIspitId);
            return View(ri);
        }

        public IActionResult DetaljiMaturskiIspitStavka(int maturskiIspitStavkaId)
        {
            //nastavnikId se može dobiti na drugi način
            RezultatiIspitaRedVM ri = _ispitiServices
                .DetaljiMaturskiIspitStavka(maturskiIspitStavkaId);
            return Ok(ri);
        }


        public IActionResult AzurirajMaturskiIspitStavka(int maturskiIspitStavkaId, int bodovi)
        {
            //nastavnikId se može dobiti na drugi način
            MatruskiIspitStavka mis = _ispitiServices
                .AzurirajMaturskiIspitStavka(maturskiIspitStavkaId, bodovi);

            return View(
                "DetaljiMaturskogIspita", 
                _ispitiServices.DetaljiMaturskogIspita(mis.MaturskiIspitId)
            );
        }

        [HttpPost]
        public IActionResult OslobodljenMaturskiIspitStavka(int maturskiIspitStavkaId)
        {
            //nastavnikId se može dobiti na drugi način
            MatruskiIspitStavka mis = _ispitiServices
                .OslobodljenMaturskiIspitStavka(maturskiIspitStavkaId);

            return View(
                "DetaljiMaturskogIspita",
                _ispitiServices.DetaljiMaturskogIspita(mis.MaturskiIspitId)
            );
        }
    }
}