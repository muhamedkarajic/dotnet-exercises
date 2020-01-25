using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.ViewModels;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.Interfaces;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class UputnicaController : Controller
    {
        private readonly IUputnicaService _uputnica;

        public UputnicaController(IUputnicaService uputnica)
        {
            _uputnica = uputnica;
        }

        [HttpPut]
        public IActionResult RezultatPretrageUpdate(RezultatPretrageUpdateViewModel rezultatPretrage)
        {
            RezultatPretrage rezultat = _uputnica.RezultatPretrageUpdate(rezultatPretrage);
            return View("Detalji", _uputnica.DetaljiUputnice(rezultat.UputnicaId));
        }

        [HttpGet]
        public IActionResult RezultatPretrage(int rezultatPretrageId)
        {
            RezultatPretrageUrediViewModel rezultati = _uputnica.RezultatPretrage(rezultatPretrageId);
            return View(rezultati);
        }

        [HttpPut]
        public IActionResult Zakljucaj(int uputnicaId)
        {
            _uputnica.ZakljucajUputnicu(uputnicaId);
            return View("Detalji", _uputnica.DetaljiUputnice(uputnicaId));
        }

        [HttpGet]
        public IActionResult Detalji(int uputnicaId)
        {
            DetaljiUputniceViewModel detaljiUputniceViewModel = _uputnica.DetaljiUputnice(uputnicaId);
            return View(detaljiUputniceViewModel);
        }

        [HttpPost]
        public IActionResult Dodaj(NovaUputnicaViewModel uputnica)
        {
            _uputnica.DodajUputnica(uputnica);
            return View("Index", _uputnica.GetUputnicaPage());
        }

        public IActionResult Index()
        {
            UputnicaPageViewModel uputnicaPageView = _uputnica.GetUputnicaPage();
            return View(uputnicaPageView);
        }
    }
}