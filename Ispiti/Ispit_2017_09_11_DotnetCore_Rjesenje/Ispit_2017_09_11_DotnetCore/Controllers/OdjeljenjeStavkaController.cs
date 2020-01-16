using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeStavkaController : Controller
    {
        private MojContext _context;

        public OdjeljenjeStavkaController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index(int odjeljenjeId)
        {
            OdjeljenjeStavkaViewModel odjeljenjeStavke = _context.Odjeljenje
                .Where(o => o.Id == odjeljenjeId)
                .Select(o => new OdjeljenjeStavkaViewModel()
                {
                    Id = o.Id,
                    SkolskaGodina = o.SkolskaGodina,
                    Razred = o.Razred,
                    Oznaka = o.Oznaka,
                    Razrednik = o.Nastavnik.ImePrezime,
                    BrojPredmeta = _context.Predmet.Count(dp => dp.Razred == o.Razred),
                    OdjeljenjaStavke = _context.OdjeljenjeStavka
                    .Where(os => os.OdjeljenjeId == odjeljenjeId)
                    .Select(os => new OdjeljenjeStavkeRowViewModel()
                    {
                        Id = os.Id,
                        BrojUDnevniku = os.BrojUDnevniku,
                        BrojZakljucenihOcjena = _context.DodjeljenPredmet
                        .Where(dp => dp.OdjeljenjeStavkaId == os.Id)
                        .Count(x => x.ZakljucnoKrajGodine > 0),
                        Ucenik = os.Ucenik.ImePrezime + " " + os.Ucenik.Id.ToString()
                    })
                    .OrderBy(x => x.BrojUDnevniku)
                    .ToHashSet()
                }).FirstOrDefault();
            
            return View(odjeljenjeStavke);
        }

        [HttpPost]
        public IActionResult DodajUcenika(int brojUDnevniku, int odjeljenjeId, string ucenik)
        {
            return Ok("Upsjesno!");
        }


        [HttpPut]
        public IActionResult Rekonstruisi(int odjeljenjeId)
        {
             HashSet<OdjeljenjeStavka> odjeljenjeStavke = _context.OdjeljenjeStavka
                .Where(os => os.OdjeljenjeId == odjeljenjeId)
                .OrderBy(os => os.Ucenik.ImePrezime)
                .ToHashSet();

            int brojac = 0;
            foreach (var odjeljenjeStavka in odjeljenjeStavke)
            {
                odjeljenjeStavka.BrojUDnevniku = ++brojac;
            }

            _context.OdjeljenjeStavka.UpdateRange(odjeljenjeStavke);
            _context.SaveChanges();

            return Ok("Uspjesno azurirano!");
        }
    }
}