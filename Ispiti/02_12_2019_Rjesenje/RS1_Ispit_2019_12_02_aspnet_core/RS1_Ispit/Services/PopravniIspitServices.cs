using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.Interfaces;
using RS1_Ispit_asp.net_core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.Services
{
    public class PopravniIspitServices: IPopravniIspitServices
    {
        private readonly MojContext _context;

        public PopravniIspitServices(MojContext context)
        {
            _context = context;
        }

        public PopravniIspitTableVM GetPopravniIspiti(int odjeljenjeId)
        {
            PopravniIspitTableVM popravniIspitTable;
            
            popravniIspitTable = _context.Odjeljenje
                .Where(o => o.Id == odjeljenjeId)
                .Select(o => new PopravniIspitTableVM {

                    Predmeti = _context.PredajePredmet
                        .Where(pp => pp.OdjeljenjeID == odjeljenjeId)
                        .Select(pp => new SelectListItem {
                            Value = pp.Predmet.Id.ToString(),
                            Text = pp.Predmet.Naziv
                        }).ToHashSet(),

                    NazivSkole = o.Skola.Naziv,

                    OznakaOdjeljenja = o.Oznaka,

                    OdjeljenjeId = o.Id,

                    SkolskaGodinaNaziv = o.SkolskaGodina.Naziv,

                    PopravniIspitRedovi = _context.PopravniIspit
                        .Where(pi => pi.OdjeljenjeID == odjeljenjeId)
                        .Select(pi => new PopravniIspitRedVM {
                            BrojUcenikaNaIspitu = pi.PopravniIspitStavke.Count(),
                            BrojUcenikaPolozili = pi.PopravniIspitStavke.Count(pis => pis.Bodovi.Value > 50),
                            DatumPopravnog = pi.DatumIspita,
                            NazivPredmet = pi.Predmet.Naziv,
                            PopravniIspitId = pi.Id
                        }).ToHashSet()
                })
                .First();

            return popravniIspitTable;
        }

        public HashSet<OdjeljenjeRedVM> GetOdjeljenja()
        {
            HashSet<OdjeljenjeRedVM> odjeljenjeRedovi = _context.Odjeljenje
                .Include(o => o.Skola)
                .Include(o => o.SkolskaGodina)
                .Select(o => new OdjeljenjeRedVM
                {
                    OdjeljenjeId = o.Id,
                    NazivSkola = o.Skola.Naziv,
                    SkolskaGodina = o.SkolskaGodina.Naziv,
                    OdjeljenjeOznaka = o.Oznaka
                })
                .ToHashSet();

            return odjeljenjeRedovi;
        }

        public void DodajPopravniIspit(int odjeljenjeId, int predmetId, DateTime datumIspita)
        {
            PopravniIspit popravniIspit = new PopravniIspit { 
                OdjeljenjeID = odjeljenjeId,
                DatumIspita = datumIspita,
                PredmetID = predmetId
            };

            _context.Add(popravniIspit);
            _context.SaveChanges();

            HashSet<PopravniIspitStavka> popravniIspitStavke = _context.DodjeljenPredmet
                .Where(dp => dp.OdjeljenjeStavka.OdjeljenjeId == odjeljenjeId && dp.PredmetId == predmetId)
                .Where(dp => dp.ZakljucnoKrajGodine == 1)
                .Select(dp => new PopravniIspitStavka {
                    Bodovi = 50,
                    OdjeljenjeStavkaId = odjeljenjeId,
                    PopravniIspitId = popravniIspit.Id,
                })
                .ToHashSet();

            //korak 3
            foreach (var popravniIspitStavka in popravniIspitStavke)
            {
                int brojJedinicaZakljucenih = _context.DodjeljenPredmet.Where(dp => dp.Id == popravniIspitStavka.OdjeljenjeStavkaId)
                    .Count(dp => dp.ZakljucnoKrajGodine == 1);
                if (brojJedinicaZakljucenih >= 3)
                    popravniIspitStavka.Bodovi = 0;
            }

            _context.AddRange(popravniIspitStavke);
            _context.SaveChanges();
        }
    }
}
