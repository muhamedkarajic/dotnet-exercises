using System.Collections.Generic;
using System.Linq;
using Ispit.Data;
using Ispit.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Controllers
{
    public class DetaljiDogadjajaController : Controller
    {
        private readonly MyContext _context;

        public DetaljiDogadjajaController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index(int dogadjajId)
        {

            DetaljiDogadjajaViewModel detaljiDogadjaja = _context.OznacenDogadjaj
                .Where(od => od.DogadjajID == dogadjajId && od.StudentID == 1)
                .OrderByDescending(od => od.DatumDodavanja)
                .Select(od => new DetaljiDogadjajaViewModel()
                {
                    ID = od.ID,
                    DatumOdrzavanja = od.Dogadjaj.DatumOdrzavanja,
                    DatumDodavanja = od.DatumDodavanja,
                    Opis = od.Dogadjaj.Opis,
                    Nastavnik = od.Dogadjaj.Nastavnik.ImePrezime,
                })
                .FirstOrDefault();

            HashSet<StanjeObavezeRedViewModel> stanjeObaveze = _context.StanjeObaveze
                .Where(so => so.OznacenDogadjajID == detaljiDogadjaja.ID)
                .Select
                (so => new StanjeObavezeRedViewModel()
                {
                    ID = so.Id,
                    Naziv = so.Obaveza.Naziv,
                    ProcenatRealizacijeObaveze = so.IzvrsenoProcentualno,
                    NotifikacijaDanaPrije = so.NotifikacijaDanaPrije,
                    NotifikacijeRekurizivno = so.NotifikacijeRekurizivno,
                })
                .ToHashSet();

            return View(new DetaljiDogadjajaParentViewModel(detaljiDogadjaja,stanjeObaveze));
        }
    }
}