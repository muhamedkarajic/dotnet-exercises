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
    public class TakmicenjeController : Controller
    {
        private readonly MojContext _context;
        public TakmicenjeController(MojContext context)
        {
            _context = context;
        }



        [HttpPost]
        public IActionResult TogglePrisustvo(int takmicenjeUcenikId, bool prisustvo)
        {
            TakmicenjeUcesnik takmicenjeUcesnik = _context.TakmicenjeUcesnik
                .Where(tu => tu.Id == takmicenjeUcenikId)
                .FirstOrDefault();
            takmicenjeUcesnik.Pristupio = prisustvo;

            _context.Update(takmicenjeUcesnik);
            _context.SaveChanges();

            return RedirectToAction("RezultatiTakmicenja", new { takmicenjeId = takmicenjeUcesnik.TakmicenjeId });
        }

        [HttpPost]
        public IActionResult AzurirajBodoveUcenika(int bodovi, int takmicenjeUcenikId)
        {

            TakmicenjeUcesnik takmicenjeUcesnik = _context.TakmicenjeUcesnik
                .Include(tu => tu.Takmicenje)
                .Where(tu => tu.Id == takmicenjeUcenikId)
                .FirstOrDefault();

            if(!takmicenjeUcesnik.Takmicenje.Zakljucano)
            {
                takmicenjeUcesnik.Bodovi = bodovi;
            }

            _context.TakmicenjeUcesnik.Update(takmicenjeUcesnik);
            _context.SaveChanges();

            return RedirectToAction("RezultatiTakmicenja", new { takmicenjeId = takmicenjeUcesnik.TakmicenjeId });
        }


        [HttpPost]
        public IActionResult DodajUcenika(int takmicenjeId, int bodovi, int odjeljenjeStavkaId)
        {

            TakmicenjeUcesnik takmicenjeUcesnik = new TakmicenjeUcesnik
            {
                Bodovi = bodovi,
                OdjeljenjeStavkaId = odjeljenjeStavkaId,
                TakmicenjeId = takmicenjeId,
                Pristupio = false,
            };


            _context.Add(takmicenjeUcesnik);
            _context.SaveChanges();

            return RedirectToAction("RezultatiTakmicenja", new { takmicenjeId = takmicenjeId });
        }

        [HttpGet]
        public IActionResult ZakljucajRezultate(int takmicenjeId)
        {
            Takmicenje t = _context.Takmicenje.Find(takmicenjeId);
            t.Zakljucano = true;
            _context.Update(t);
            _context.SaveChanges();

            return RedirectToAction("RezultatiTakmicenja", new { takmicenjeId = takmicenjeId });
        }

        public IActionResult DodajUrediUcenika(int takmicenjeId, int takmicenjeUcenikId)
        {
            int razred = _context.Takmicenje.Find(takmicenjeId).Razred;
            DodajUrediUcenikaVM dodajUrediUcenika = new DodajUrediUcenikaVM();
            dodajUrediUcenika.TakmicenjeId = takmicenjeId;
            dodajUrediUcenika.TakmicenjeUcenikId = takmicenjeUcenikId;

            if (takmicenjeUcenikId == 0)
            {
                dodajUrediUcenika.Ucenici = _context.OdjeljenjeStavka
                    .Include(os => os.Odjeljenje)
                    .Include(os => os.Ucenik)
                    .OrderBy(os => os.Id)
                    .Where(os => _context.TakmicenjeUcesnik.Count(tu => tu.OdjeljenjeStavkaId == os.Id) == 0)//ucenici koji nisu na listi
                    //.Where(os => os.Odjeljenje.Razred == razred || razred == 0)//ucenici koji su iz tih razreda
                    .Select(os => new SelectListItem
                    {
                        Value = os.Id.ToString(),
                        Text = os.Odjeljenje.Oznaka + " " + os.Ucenik.ImePrezime
                    }).ToHashSet();

                dodajUrediUcenika.Bodovi = 0;
            }
            else
            {
                TakmicenjeUcesnik takmicenjeUcenik = _context.TakmicenjeUcesnik
                    .Include(tu => tu.OdjeljenjeStavka)
                    .Include(tu => tu.OdjeljenjeStavka.Ucenik)
                    .Where(tu => tu.Id == takmicenjeUcenikId)
                    .FirstOrDefault();

                dodajUrediUcenika.Bodovi = takmicenjeUcenik != null ? takmicenjeUcenik.Bodovi : 0;
                dodajUrediUcenika.UcenikImePrezime = takmicenjeUcenik != null ? takmicenjeUcenik.OdjeljenjeStavka.Ucenik.ImePrezime : null;

            }

            return View(dodajUrediUcenika);
        }

        [HttpGet]
        public IActionResult RezultatiTakmicenja(int takmicenjeId)
        {
            RezultatiTakmicenjaTabelaVM rezultatiTakmicenjaTabela = new RezultatiTakmicenjaTabelaVM();

            rezultatiTakmicenjaTabela.RezultatiTakmicenjaRedovi = _context.TakmicenjeUcesnik
                .Where(tu => tu.TakmicenjeId == takmicenjeId)
                .OrderByDescending(tu => tu.Bodovi)
                .Select(tu => new RezultatiTakmicenjaRedVM {
                    TakmicenjeUcenikId = tu.Id,
                    Bodovi = tu.Bodovi,
                    BrojUDnevniku = tu.OdjeljenjeStavka.BrojUDnevniku,
                    Odjeljenje = tu.OdjeljenjeStavka.Odjeljenje.Oznaka,
                    Pristupio = tu.Pristupio,
                }).ToHashSet();


            Takmicenje takmicenje = _context.Takmicenje
                .Include(t => t.Predmet)
                .Include(t => t.Skola)
                .Where(t => t.Id == takmicenjeId)
                .First();
            rezultatiTakmicenjaTabela.Razred = takmicenje.Razred;
            rezultatiTakmicenjaTabela.PredmetNaziv = takmicenje.Predmet.Naziv;
            rezultatiTakmicenjaTabela.Datum = takmicenje.Datum;
            rezultatiTakmicenjaTabela.SkolaDomacin = takmicenje.Skola.Naziv;
            rezultatiTakmicenjaTabela.takmicenjeId = takmicenjeId;

            rezultatiTakmicenjaTabela.Zakljucano = takmicenje.Zakljucano;

            return View(rezultatiTakmicenjaTabela);
        }

        [HttpPost]
        public IActionResult DodajTakmicenje(int skolaId, string nazivPredmeta, int razred, DateTime datum)
        {
            int predmetId = _context.Predmet.Where(p => p.Naziv == nazivPredmeta && p.Razred == razred).First().Id;

            Takmicenje takmicenje = new Takmicenje
            {
                Datum = datum,
                PredmetId = predmetId,
                Razred = razred,
                SkolaId = skolaId,
            };

            _context.Add(takmicenje);
            _context.SaveChanges();

            List<TakmicenjeUcesnik> takmicenjeUcesnici = _context.OdjeljenjeStavka
                .Where(
                    os => os.DodjeljenPredmets
                        .Where(dp => dp.PredmetId == predmetId)
                        .Count(dp => dp.ZakljucnoKrajGodine == 5) > 0

                    ||

                    os.DodjeljenPredmets
                        .Average(dp => dp.ZakljucnoKrajGodine) >= 4.0
                )
                .Select(os => new TakmicenjeUcesnik
                {
                    OdjeljenjeStavkaId = os.Id,
                    TakmicenjeId = takmicenje.Id,
                    Pristupio = false,
                    Bodovi = 0,
                })
                .ToList();


            _context.AddRange(takmicenjeUcesnici);
            _context.SaveChanges();

            return RedirectToAction("PrikazTakmicenja", new { razred = razred, skolaId = skolaId });
        }

        [HttpGet]
        public IActionResult PrikazTakmicenja(int razred, int skolaId)
        {
            PrikazTakmicenjaTableVM prikazTakmicenjaTabla = new PrikazTakmicenjaTableVM();

            prikazTakmicenjaTabla.PrikazTakmicenjaRedovi = _context.Takmicenje
                .Where(t => t.SkolaId == skolaId)
                .Where(t => t.Razred == razred || razred == 0)
                .Select(t => new PrikazTakmicenjaRedVM
                {
                    TakmicenjeId = t.Id,
                    NazivPredmeta = t.Predmet.Naziv,
                    Razred = t.Razred,
                    Datum = t.Datum,

                    BrojUcenikaNisuPristupili = t.TakmicenjeUcenika
                        .Count(tu => tu.Pristupio == false),

                    NajboljiUcenikSkola = t.TakmicenjeUcenika
                        .OrderByDescending(tu => tu.Bodovi)
                        .Select(tu => tu.Takmicenje.Skola.Naziv)
                        .FirstOrDefault(),

                    NajboljiUcenikOdjeljenje = t.TakmicenjeUcenika
                        .OrderByDescending(tu => tu.Bodovi)
                        .Select(tu => tu.OdjeljenjeStavka.Odjeljenje.Oznaka)
                        .FirstOrDefault(),

                    NajboljiUcenikImePrezime = t.TakmicenjeUcenika
                        .OrderByDescending(tu => tu.Bodovi)
                        .Select(tu => tu.OdjeljenjeStavka.Ucenik.ImePrezime)
                        .FirstOrDefault(),

                }).ToList();

            prikazTakmicenjaTabla.SkolaId = skolaId;

            prikazTakmicenjaTabla.SkolaNaziv = _context.Skola.Find(skolaId).Naziv;

            prikazTakmicenjaTabla.Razred = razred;

            prikazTakmicenjaTabla.Predmeti = _context.Predmet
                    .Where(p => p.Razred == razred || razred == 0)
                    .OrderByDescending(p => p.Razred)
                    .OrderByDescending(p => p.Naziv)
                    .Select(p => new SelectListItem
                    {
                        Value = p.Naziv,
                        Text = p.Naziv
                    })
                    .Distinct()
                    .ToHashSet();

            return View(prikazTakmicenjaTabla);
        }

        public IActionResult Index()
        {
            List<SelectListItem> skole = _context.Skola
                .OrderBy(s => s.Naziv)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Naziv,
                }).ToList();

            return View(skole);
        }
    }
}