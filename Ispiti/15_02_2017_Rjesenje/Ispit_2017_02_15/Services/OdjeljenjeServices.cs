using Ispit_2017_02_15.EF;
using Ispit_2017_02_15.Models;
using Ispit_2017_02_15.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_02_15.Interfaces;

namespace Ispit_2017_02_15.Services
{
    public class OdjeljenjeServices: IOdjeljenjeServices
    {

        private MojContext _context;
        private IHttpContextAccessor _httpContext;
        public OdjeljenjeServices(MojContext db, IHttpContextAccessor httpContext)
        {
            this._context = db;
            this._httpContext = httpContext;
        }
        public OdrzaniCasoviTabelaViewModel OdrzaniCasoviTabela(int nastavnikId)
        {
            OdrzaniCasoviTabelaViewModel odrzaniCasoviTabela = new OdrzaniCasoviTabelaViewModel();
            odrzaniCasoviTabela.NastavnikId = nastavnikId;

            Nastavnik n = _context.Nastavnik.Find(nastavnikId);

            odrzaniCasoviTabela.ImePrezimeNastavnika = n.Ime[0] + ". " + n.Prezime + ".";

            odrzaniCasoviTabela.OdrzaniCasRed = _context.OdrzaniCasovi
                .Include(oc => oc.Angazovan)
                .ThenInclude(a => a.AkademskaGodina)
                .Include(oc => oc.Angazovan.AkademskaGodina)
                .Where(oc => oc.Angazovan.NastavnikId == nastavnikId)
                .Select(oc => new OdrzaniCasoviRedViewModel
                {
                    Id = oc.Id,
                    Datum = oc.Datum,
                    NazivPredmeta = oc.Angazovan.Predmet.Naziv,
                    OpisAkademskeGodine = oc.Angazovan.AkademskaGodina.Opis,
                    BrojStudenata = _context.OdrzaniCasDetalji.Where(ocd => ocd.OdrzaniCasId == oc.Id).Count(),
                    BrojPrisutnih = _context.OdrzaniCasDetalji.Where(ocd => ocd.OdrzaniCasId == oc.Id && ocd.Prisutan == true).Count(),
                    ProsjecnaOcjena = _context.SlusaPredmet.Where(sp => sp.AngazovanId == oc.AngazovanId).Select(sp => sp.Ocjena).Average() ?? 0,
                }).ToHashSet();


            odrzaniCasoviTabela.AkGodPredmeti = _context.Angazovan
                .Include(a => a.Predmet)
                .Include(a => a.AkademskaGodina)
                .Where(a => a.NastavnikId == nastavnikId)
                .Select(a => new SelectListItem
                {
                    Value = a.PredmetId.ToString(),
                    Text = a.AkademskaGodina.Opis + "/" + a.Predmet.Naziv
                }).ToList();

            return odrzaniCasoviTabela;
        }


        public void DodajNoviCas(NoviCasViewModel cas)
        {
            Angazovan angazovan = _context.Angazovan
                .Where(a => a.NastavnikId == cas.nastavnikId && a.PredmetId == cas.predmetId)
                .FirstOrDefault();


            OdrzaniCas noviOdrzaniCas = new OdrzaniCas
            {
                AngazovanId = angazovan.Id,
                Datum = cas.datum,
            };

            _context.OdrzaniCasovi.Add(noviOdrzaniCas);
            _context.SaveChanges();

            List<OdrzaniCasDetalji> odrzaniCasDetalji = _context.SlusaPredmet
                .Where(sp => sp.Angazovan.PredmetId == cas.predmetId)
                .Select(sp => new OdrzaniCasDetalji
                {
                    OdrzaniCasId = noviOdrzaniCas.Id,
                    BodoviNaCasu = 0,
                    Prisutan = false,
                    SlusaPredmetId = sp.Id
                }).ToList();


            _context.OdrzaniCasDetalji.AddRange(odrzaniCasDetalji);
            _context.SaveChanges();
        }



        public HashSet<OdrzaniCasDetaljiTabelaViewModel> OdrzaniCasDetalji(int odrzanCasId)
        {
            int nastavnikId = 2;

            HashSet<OdrzaniCasDetaljiTabelaViewModel> odrzaniCasDetalji = _context.OdrzaniCasDetalji
                .Include(ocd => ocd.SlusaPredmet)
                .Where(ocd => ocd.OdrzaniCasId == odrzanCasId)
                .Select(ocd => new OdrzaniCasDetaljiTabelaViewModel
                {
                    OdrzaniCasDetaljiId = ocd.Id,
                    Bodovi = ocd.BodoviNaCasu,
                    Prisutan = ocd.Prisutan,
                    ImeStuenta = ocd.SlusaPredmet.UpisGodine.Student.Ime,
                    PrezimeStuenta = ocd.SlusaPredmet.UpisGodine.Student.Prezime
                }).ToHashSet();

            return odrzaniCasDetalji;
        }
    }
}
