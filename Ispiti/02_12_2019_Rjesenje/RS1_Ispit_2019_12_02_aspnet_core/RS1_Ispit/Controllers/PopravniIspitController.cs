using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.Interfaces;
using RS1_Ispit_asp.net_core.ViewModel;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class PopravniIspitController : Controller
    {
        private readonly MojContext _context;

        public readonly IPopravniIspitServices _popravniIspit;

        public PopravniIspitController(MojContext context, IPopravniIspitServices popravniIspit)
        {
            _context = context;
            _popravniIspit = popravniIspit;
        }

        public IActionResult Index()
        {
            return View(_popravniIspit.GetOdjeljenja());
        }


        public IActionResult GetPopravniIspiti(int odjeljenjeId)
        {
            return View(_popravniIspit.GetPopravniIspiti(odjeljenjeId));
        }

        [HttpPost]
        public IActionResult DodajPopravniIspit(int odjeljenjeId, int predmetId, DateTime datumIspita)
        {
            _popravniIspit.DodajPopravniIspit(odjeljenjeId, predmetId, datumIspita);
            return RedirectToAction("GetPopravniIspiti", new { odjeljenjeId = odjeljenjeId });
        }

        public IActionResult UrediPopravniIspit(int popravniIspitId)
        {


            return View(_popravniIspit.UrediPopravniIspit(popravniIspitId));
        }



    }
}