using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Web.Controllers
{
    public class NotifikacijeController : Controller
    {
        private readonly MyContext _context;

        public NotifikacijeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Procitano(int poslataNotifikacijaId)
        {
            PoslataNotifikacija notifikacija = _context.PoslataNotifikacija.Find(poslataNotifikacijaId);
            //provjeriti da li notifikacija pripada studentu preko studentId 
            notifikacija.IsProcitano = true;
            _context.PoslataNotifikacija.Update(notifikacija);
            _context.SaveChanges();

            return Ok("Notifikacija je uspjesno procitana!");
        }
    }
}