using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Ispit.Web.ViewModels;

namespace Ispit.Web.Controllers
{
    [Autorizacija]
    public class OznaceniDogadajiController : Controller
    {
        private readonly MyContext _context;

        public OznaceniDogadajiController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HashSet<Notifikacija> notifikacije = new HashSet<Notifikacija>();
            HashSet<DogadajiRedViewModel> oznaceniDogadjaji = _context.OznacenDogadjaj
                .Where(od => od.StudentID == 1)//treba staviti koji je student logiran, nisam upućen kako
                .Select(od => new DogadajiRedViewModel
                (
                    od.ID,
                    od.Dogadjaj.DatumOdrzavanja,
                    od.Dogadjaj.Nastavnik.ImePrezime,
                    od.Dogadjaj.Opis,
                    0,//nisam siguran kako uraditi preko EF
                    od.DogadjajID
                )
                { }).ToHashSet();


            foreach (var oznacenDogadjaj in oznaceniDogadjaji)
            {
                HashSet<Obaveza> obaveze = _context.Obaveza
                    .Where(o => o.DogadjajID == oznacenDogadjaj.DogadjajID)
                    .ToHashSet();

                int brojObaveza = obaveze.Count();
                float sumaObaveze = 0;
                foreach (var obaveza in obaveze)
                {
                    StanjeObaveze stanjeObaveze = _context.StanjeObaveze
                            .Where(so => so.ObavezaID == obaveza.ID)
                            .OrderByDescending(so => so.DatumIzvrsenja)
                            .FirstOrDefault();

                    if (stanjeObaveze != null)
                    {
                        sumaObaveze += stanjeObaveze.IzvrsenoProcentualno / brojObaveza;
                    }

                }
                oznacenDogadjaj.BrojObaveza = sumaObaveze;

                //Zadatak 3
                StanjeObaveze stanjeObaveza = _context.StanjeObaveze
                    .Where(so => so.OznacenDogadjajID == oznacenDogadjaj.ID)
                    .Include(so => so.OznacenDogadjaj)
                    .Include(so => so.Obaveza)
                    .ThenInclude(o => o.Dogadjaj)
                    .OrderByDescending(so => so.DatumIzvrsenja)
                    .FirstOrDefault();

                if (stanjeObaveza != null && oznacenDogadjaj.DatumDogadjanja.CompareTo(
                        DateTime.Now.AddDays(stanjeObaveza.Obaveza.NotifikacijaDanaPrijeDefault
                    )) == -1)
                {

                    PoslataNotifikacija poslataNotifikacija = _context.PoslataNotifikacija
                            .OrderByDescending(pn => pn.DatumSlanja)
                            .FirstOrDefault();

                    if (poslataNotifikacija == null)
                    {
                        poslataNotifikacija = new PoslataNotifikacija(stanjeObaveza.Id);
                        _context.PoslataNotifikacija.Add(poslataNotifikacija);
                    }

                    if (!poslataNotifikacija.IsProcitano)
                    {
                        notifikacije.Add(
                            new Notifikacija
                            (
                                stanjeObaveza.Obaveza.Naziv, 
                                stanjeObaveza.Obaveza.Dogadjaj.DatumOdrzavanja, 
                                stanjeObaveza.OznacenDogadjaj.Dogadjaj.Opis, 
                                poslataNotifikacija.Id
                            ));
                    }
                }
            }


            HashSet<DogadajiRedViewModel> neoznaceniDogadjaji = _context.Dogadjaj
                .Where(d => oznaceniDogadjaji.Where(od => od.DogadjajID == d.ID).FirstOrDefault() == null)
                .Select(d => new DogadajiRedViewModel
                (
                    d.ID,
                    d.DatumOdrzavanja,
                    d.Nastavnik.ImePrezime,
                    d.Opis,
                    _context.Obaveza.Where(o => o.DogadjajID == d.ID).Count(),
                    d.ID
                )
                { }).ToHashSet();

            _context.SaveChanges();

            return View(new TabeleDogadjajiViewModel(oznaceniDogadjaji, neoznaceniDogadjaji, notifikacije));
        }

        [HttpGet]
        public IActionResult DodajDogadjaj(int dogadjejId)
        {
            Dogadjaj dogadjaj = _context.Dogadjaj.Find(dogadjejId);

            if (dogadjaj.DatumOdrzavanja.CompareTo(DateTime.Now) == -1)
                return BadRequest("Nije moguće dodati događaj koji je već istekao.");

            OznacenDogadjaj oznacenDogadjajPostoji = _context.OznacenDogadjaj
                .Where(od => od.DogadjajID == dogadjejId && od.StudentID == 1)
                .FirstOrDefault();

            if (oznacenDogadjajPostoji != null)
            {
                return BadRequest("Oznaceni dogadjaj je već dodan.");
            }

            OznacenDogadjaj oznacenDogadjaj = new OznacenDogadjaj(1, dogadjejId);//id studenta
            _context.OznacenDogadjaj.Add(oznacenDogadjaj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}