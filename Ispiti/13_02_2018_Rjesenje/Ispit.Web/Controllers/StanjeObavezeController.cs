using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ispit.Web.Controllers
{
    public class StanjeObavezeController : Controller
    {
        private readonly MyContext _context;

        public StanjeObavezeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index(int stanjeObavezeId)
        {
            StanjeObaveze stanjeObaveze = _context.StanjeObaveze.Where(so => so.Id == stanjeObavezeId).Include(so => so.Obaveza).FirstOrDefault();
            var stanje = new
            {
                IzvrsenoProcentualno = stanjeObaveze.IzvrsenoProcentualno,
                Naziv = stanjeObaveze.Obaveza.Naziv
            };
            return Ok(stanje);
        }
        
        [HttpPut]
        public IActionResult Azuriraj(int stanjeObavezeId, float procenatStanjaObaveze)
        {
            StanjeObaveze stanjeObaveze = _context.StanjeObaveze
                .Where(so => so.Id == stanjeObavezeId)
                .Include(so => so.Obaveza)
                .FirstOrDefault();

            if(procenatStanjaObaveze == 100)
            {
                stanjeObaveze.IsZavrseno = true;   
            }
            else
            {
                stanjeObaveze.IsZavrseno = false;

            }
            stanjeObaveze.IzvrsenoProcentualno = procenatStanjaObaveze;
            _context.StanjeObaveze.Update(stanjeObaveze);
            _context.SaveChanges();

            return Ok("Uspjesno azurirano!");
        }
    }
}