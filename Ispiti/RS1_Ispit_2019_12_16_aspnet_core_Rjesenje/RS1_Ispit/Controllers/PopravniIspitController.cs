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

        private readonly MojContext _context;

        public PopravniIspitController(MojContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult DodajUcenikaPopravnomIspitu(int popravniIspitId, int odjeljenjeStavkaId, double? bodovi)
        {
            if(bodovi == 0)//nema pravo na popravni
            {
                bodovi = null;
            }

            PopravniIspitStavka popravniIspitStavka = new PopravniIspitStavka
            {
                Bodovi = bodovi,
                OdjeljenjeStavkaId = odjeljenjeStavkaId,
                Prisutan = bodovi > 0,
                PopravniIspitId = popravniIspitId
            };
            _context.Add(popravniIspitStavka);
            _context.SaveChanges();

            return RedirectToAction("UrediPopravniIspit", new { popravniIspitId = popravniIspitId });
        }


        [HttpGet]
        public IActionResult DodajUcenikaForm(int popravniIspitId)
        {
            DodajUcenikaVM dodajUcenikaVM = new DodajUcenikaVM();
            dodajUcenikaVM.PopravniIspitId = popravniIspitId;

            HashSet<PopravniIspitStavka> popravniIspitStavka = _context.PopravniIspitStavka
                .Where(pis => pis.PopravniIspitId == popravniIspitId)
                .ToHashSet();
            
            dodajUcenikaVM.Ucenici = _context.OdjeljenjeStavka
                .Where(os => popravniIspitStavka.Count(pis => pis.OdjeljenjeStavkaId == os.Id) == 0)
                .Select(os => new SelectListItem
                {
                    Value = os.Id.ToString(),
                    Text = os.Ucenik.ImePrezime
                }).ToHashSet();

            return View(dodajUcenikaVM);
        }


        [HttpPost]
        public IActionResult IzmjeniBodoveUceniku(int popravniIspitStavkaId, double bodovi)
        {
            PopravniIspitStavka popravniIspitStavka = _context.PopravniIspitStavka
                .Include(pis => pis.OdjeljenjeStavka)
                .Include(pis => pis.OdjeljenjeStavka.Ucenik)
                .Where(pis => pis.Id == popravniIspitStavkaId)
                .First();

            popravniIspitStavka.Bodovi = bodovi;

            _context.Update(popravniIspitStavka);
            _context.SaveChanges();

            return RedirectToAction("UrediPopravniIspit", new { popravniIspitId = popravniIspitStavka.PopravniIspitId });
        }

        [HttpGet]
        public IActionResult UcenikaPopravnogIspita(int popravniIspitStavkaId)
        {
            UcenikaPopravnogIspitaVM ucenikaPopravnogIspitaVM =_context.PopravniIspitStavka
                .Include(pis => pis.OdjeljenjeStavka)
                .Include(pis => pis.OdjeljenjeStavka.Ucenik)
                .Where(pis => pis.Id == popravniIspitStavkaId)
                .Select(pis => new UcenikaPopravnogIspitaVM { 
                    BodoviUcenika = pis.Bodovi,
                    ImePrezimeUcenika = pis.OdjeljenjeStavka.Ucenik.ImePrezime,
                    PopravniIspitStavkaId = pis.Id
                })
                .First();
            return View(ucenikaPopravnogIspitaVM);



        }

        [HttpGet]
        public IActionResult PopravniIspitStavkaToggle(int popravniIspitStavkaId)
        {
            PopravniIspitStavka popravniIspitStavka = _context.PopravniIspitStavka
                .Where(pis => pis.Id == popravniIspitStavkaId)
                .First();

            popravniIspitStavka.Prisutan = !popravniIspitStavka.Prisutan;

            _context.Update(popravniIspitStavka);
            _context.SaveChanges();

            return RedirectToAction("UrediPopravniIspit", new { popravniIspitId = popravniIspitStavka.PopravniIspitId });
        }

        [HttpGet]
        public IActionResult UrediPopravniIspit
        (
            int popravniIspitId
        )
        {
            UrediPopravniIspitTabelaVM urediPopravniIspitTabelaVM = _context.PopravniIspit
                .Include(pi => pi.PopravniIspitStavke)
                .ThenInclude(pis => pis.OdjeljenjeStavka)
                .Where(pi => pi.Id == popravniIspitId)
                .Select(pi => new UrediPopravniIspitTabelaVM
                {
                    PopravniIspitId = pi.Id,
                    Datum = pi.DatumIspita,
                    PredmetId = pi.PredmetId,
                    Nastavnik1Id = pi.NastavnikId1,
                    Nastavnik2Id = pi.NastavnikId2,
                    Nastavnik3Id = pi.NastavnikId3,
                    SkolaId = pi.SkolaId,
                    SkolskaGodinaId = pi.SkolskaGodinaId,

                    UrediPopravniIspitRedVMs = pi.PopravniIspitStavke
                        .Select(pis => new UrediPopravniIspitRedVM { 
                            PopravniIspitStavkaId = pis.Id,
                            Bodovi = pis.Bodovi,
                            BrojUDnevniku = pis.OdjeljenjeStavka.BrojUDnevniku,
                            OdjeljenjeOznaka = pis.OdjeljenjeStavka.Odjeljenje.Oznaka,
                            Prisutan = pis.Prisutan,
                            UcenikImePrezime = pis.OdjeljenjeStavka.Ucenik.ImePrezime
                        }).ToHashSet(),

                    Nastavnik1ImePrezime = _context.Nastavnik
                        .Where(n => n.Id == pi.NastavnikId1)
                        .Select(n => n.Ime + " " + n.Prezime)
                        .First(),

                    Nastavnik2ImePrezime = _context.Nastavnik
                        .Where(n => n.Id == pi.NastavnikId2)
                        .Select(n => n.Ime + " " + n.Prezime)
                        .First(),

                    Nastavnik3ImePrezime = _context.Nastavnik
                        .Where(n => n.Id == pi.NastavnikId3)
                        .Select(n => n.Ime + " " + n.Prezime)
                        .First(),

                    PredmetNaziv = pi.Predmet.Naziv,
                    SkolaNaziv = pi.Skola.Naziv,
                    SkolskaGodinaNaziv = pi.SkolskaGodina.Naziv
                }).First();

            return View(urediPopravniIspitTabelaVM);

        }





        [HttpPost]
        public IActionResult DodajPopravniIspit
        (
            int skolaId, int predmetId, int skolskaGodinaId,
            int nastavnik1Id, int nastavnik2Id, int nastavnik3Id,
            DateTime datum
        )
        {
            PopravniIspit popravniIspit = new PopravniIspit
            {
                NastavnikId1 = nastavnik1Id,
                NastavnikId2 = nastavnik2Id,
                NastavnikId3 = nastavnik3Id,
                DatumIspita = datum,
                PredmetId = predmetId,
                SkolaId = skolaId,
                SkolskaGodinaId = skolskaGodinaId
            };

            _context.Add(popravniIspit);
            _context.SaveChanges();



            List<PopravniIspitStavka> odjeljenjaStavke = _context.OdjeljenjeStavka
              .Where(os => os.DodjeljeniPredmeti.Count(dp => dp.ZakljucnoKrajGodine == 1 && dp.PredmetId == predmetId) > 0)
              .Select(os => new PopravniIspitStavka
              {
                  OdjeljenjeStavkaId = os.Id,
                  PopravniIspitId = popravniIspit.Id,
                  Prisutan = false,
                  Bodovi = (os.DodjeljeniPredmeti.Count(dp => dp.ZakljucnoKrajGodine == 1)) >= 3 ? 0.0 : (double?)(null),
              }).ToList();

            _context.AddRange(odjeljenjaStavke);
            _context.SaveChanges();



            return RedirectToAction("PrikazPopravnihIspita", new { skolaId = skolaId, predmetId = predmetId, skolskaGodinaId = skolskaGodinaId });
        }

        public IActionResult PrikazPopravnihIspita(int skolaId, int predmetId, int skolskaGodinaId)
        {
            PopravniIspitTabelaVM popravniIspitTabelaVM = new PopravniIspitTabelaVM();
            popravniIspitTabelaVM.SkolaId = skolaId;
            popravniIspitTabelaVM.PredmetId = predmetId;
            popravniIspitTabelaVM.SkolskaGodinaId = skolskaGodinaId;

            try
            {
                popravniIspitTabelaVM.SkolaNaziv = _context.Skola.Find(skolaId).Naziv;
                popravniIspitTabelaVM.PredmetNaziv = _context.Predmet.Find(predmetId).Naziv;
                popravniIspitTabelaVM.SkolskaGodinaNaziv = _context.SkolskaGodina.Find(skolskaGodinaId).Naziv;
            }
            catch (Exception ex)
            {
                return BadRequest("Parametri su pogrešni.");
            };

            popravniIspitTabelaVM.PopravniIspitRedVMs = _context.PopravniIspit
                .Where(p => p.SkolaId == skolaId)
                .Where(p => p.PredmetId == predmetId)
                .Where(p => p.SkolskaGodinaId == skolskaGodinaId)
                .Select(p => new PopravniIspitRedVM
                {
                    PopravniIspitId = p.Id,
                    DatumIspita = p.DatumIspita,
                    NastavnikImePrezime = _context.Nastavnik
                        .Where(n => n.Id == p.NastavnikId1)
                        .Select(n => n.Ime + " " + n.Prezime)
                        .First(),
                    UceniciNaIspitu = p.PopravniIspitStavke.Count(),
                    BrojProlaznosti = p.PopravniIspitStavke.Where(pi => pi.Bodovi >= 50).Count()
                }).ToHashSet();

            popravniIspitTabelaVM.Nastavnici = _context.Nastavnik
                .Where(n => n.SkolaID == skolaId)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Ime + " " + n.Prezime,
                }).ToHashSet();


            return View(popravniIspitTabelaVM);
        }

        public IActionResult Index()
        {
            OdabirVM odabirVM = new OdabirVM();

            odabirVM.Skole = _context.Skola
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Naziv
                }).ToHashSet();

            odabirVM.Predmeti = _context.Predmet
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Naziv
                }).ToHashSet();

            odabirVM.SkolskeGodine = _context.SkolskaGodina
                //.Where(s => s.Aktuelna == true) 
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Naziv
                }).ToHashSet();


            return View(odabirVM);
        }
    }
}