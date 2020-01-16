using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        private MojContext _context;

        public OdjeljenjeController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HashSet<OdjeljenjaTabelaViewModel> odjeljenjaTabela = _context.Odjeljenje
                .Include(n => n.Nastavnik)
                .Select(o => new OdjeljenjaTabelaViewModel
                (
                    o.Id,
                    o.SkolskaGodina,
                    o.Razred,
                    o.Oznaka,
                    o.Nastavnik.ImePrezime,
                    o.IsPrebacenuViseOdjeljenje,

                    _context.DodjeljenPredmet
                        .Include(os => os.OdjeljenjeStavka)
                        .Where(os => os.OdjeljenjeStavka.OdjeljenjeId == o.Id)
                        .Average(dp => (int?)dp.ZakljucnoKrajGodine) ?? 0,

                    _context.DodjeljenPredmet
                        .Include(dp => dp.OdjeljenjeStavka)
                        .Where(dp => dp.OdjeljenjeStavka.OdjeljenjeId == o.Id)
                        .GroupBy(dp => dp.OdjeljenjeStavka.UcenikId)
                        .Select(g => g.Average(x => (int?)x.ZakljucnoKrajGodine) ?? 0)
                        .OrderByDescending(g => g)
                        .FirstOrDefault()
                )
                { }).ToHashSet();

             HashSet<SelectListItem> odjeljenja = 
                _context.Odjeljenje
                    .Where(o => o.IsPrebacenuViseOdjeljenje == false)
                    .Select(o => new SelectListItem()
                    {
                        Text = o.SkolskaGodina + ", " + o.Oznaka,
                        Value = o.Id.ToString()
                    }).ToHashSet();

            HashSet<SelectListItem> razrednici =
                _context.Nastavnik.Select(o => new SelectListItem()
                {
                    Text = o.ImePrezime,
                    Value = o.NastavnikID.ToString()
                }).ToHashSet();

            return View(new OdjeljenjaViewModel(odjeljenjaTabela, razrednici, odjeljenja));
        }

        [HttpPost]
        public IActionResult DodajOdjeljenje(NovoOdjeljenje novoOdjeljenje)
        {
            Odjeljenje o2 = new Odjeljenje {
                NastavnikID = novoOdjeljenje.RazrednikId,
                Oznaka = novoOdjeljenje.Oznaka,
                SkolskaGodina = novoOdjeljenje.SkolskaGodina,
                Razred = novoOdjeljenje.Razred
            };
            _context.Odjeljenje.Add(o2);
            _context.SaveChanges();

            if (novoOdjeljenje.OdjeljenjeId != 0)
            {

                Odjeljenje staroOdjeljenje = _context.Odjeljenje.Find(novoOdjeljenje.OdjeljenjeId);
                staroOdjeljenje.IsPrebacenuViseOdjeljenje = true;
                _context.Odjeljenje.Update(staroOdjeljenje);

                HashSet<OdjeljenjeStavka> odjeljenjeStavke = _context.OdjeljenjeStavka
                    .Where
                    (
                        os => os.OdjeljenjeId == novoOdjeljenje.OdjeljenjeId &&
                        _context.DodjeljenPredmet.Where(dp => dp.OdjeljenjeStavkaId == os.Id).Count(dp => dp.ZakljucnoKrajGodine == 1) == 0
                    )
                    .Select(osn => new OdjeljenjeStavka()
                    {
                        BrojUDnevniku = 0,
                        OdjeljenjeId = o2.Id,
                        UcenikId = osn.UcenikId,
                    })
                    .ToHashSet();

                
                _context.OdjeljenjeStavka.AddRange(odjeljenjeStavke);
                _context.SaveChanges();
            }

            return Ok("Uspjesno dodano!");
        }

        [HttpDelete]
        public IActionResult ObrisiOdjeljenje(int odjeljenjeId)
        {
            Odjeljenje odjeljenje = _context.Odjeljenje.Find(odjeljenjeId);

            try
            {
                HashSet<OdjeljenjeStavka> odjeljenjaStavke = _context.OdjeljenjeStavka.Where(os => os.OdjeljenjeId == odjeljenjeId).ToHashSet();
                _context.OdjeljenjeStavka.RemoveRange(odjeljenjaStavke);
                _context.SaveChanges();

                foreach (var odjeljenjeStavka in odjeljenjaStavke)
                {
                    _context.DodjeljenPredmet
                        .RemoveRange
                        (
                            _context.DodjeljenPredmet
                            .Where(dp => dp.OdjeljenjeStavkaId == odjeljenjeStavka.Id)
                            .ToHashSet()
                        );
                }

                _context.Odjeljenje.Remove(odjeljenje);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR C404: ", ex.Message);
                return BadRequest("Odjeljenje ne postoji il je već obrisano.");
            }

            return Ok("Odjeljenje i stavke uspjesno obrisano.");
        }

    }
}