using RS1_Ispit_2017_06_21_v1.EF;
using RS1_Ispit_2017_06_21_v1.Interfaces;
using RS1_Ispit_2017_06_21_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_2017_06_21_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RS1_Ispit_2017_06_21_v1.Services
{
    public class IspitiServices:IIspitiServices
    {
        private readonly int _nastavnikId = 1;
        private readonly MojContext _context;

        public IspitiServices(MojContext db)
        {
            _context = db;
        }

        public MaturskiIspitTableVM GetMaturskiIspitiTable()
        {
            MaturskiIspitTableVM m = new MaturskiIspitTableVM
            {
                MaturskiIspitRedovi = _context.MaturskiIspit
                    //.Where(mi => mi.NastavnikId == _nastavnikId)//piše u zadatku svi
                    .Select(mi => new MaturskiIspitRedVM
                    {
                        MaturskiIspitId = mi.Id,
                        Datum = mi.Datum,
                        Ispitivac = mi.Nastavnik.ImePrezime,
                        Odjeljenje = mi.Odjeljenje.Naziv,
                        ProsjecniBodovi = _context.MaturskiIspitStavka
                        .Where(mis => mis.MaturskiIspitId == mi.Id)
                        .Average(mis => mis.Bodovi) ?? 0,
                        IspitivacId = mi.NastavnikId
                    }).ToHashSet(),

                Ispitivac = _context.Nastavnik.Find(_nastavnikId).ImePrezime,

                Odjeljenja = _context.Odjeljenje
                    .Where(o => o.NastavnikId == _nastavnikId)
                    .Select(o => new SelectListItem { 
                        Value = o.Id.ToString(),
                        Text = o.Naziv
                    }).ToList(),

                IspitivacId = _nastavnikId //dodan parametar pošto ne koristim Auth
            };

            return m;
        }

        public void NoviMaturskiIspit(DateTime datum, int odjeljenjeId)
        {
            MaturskiIspit noviMaturskiIspit = new MaturskiIspit
            {
                Datum = datum,
                OdjeljenjeId = odjeljenjeId,
                NastavnikId = _nastavnikId
            };

            _context.MaturskiIspit.Add(noviMaturskiIspit);
            _context.SaveChanges();

            HashSet<UpisUOdjeljenje> upisiUOdjeljenja = _context.UpisUOdjeljenje
                .Where(uuo => uuo.OdjeljenjeId == odjeljenjeId && uuo.OpciUspjeh > 1)
                //pocetak zadataka 3b
                .Where(uuo =>
                    uuo.MatruskiIspitStavke
                        .OrderByDescending(mis => mis.Id)
                        .FirstOrDefault().Oslobodjen != true 
                        
                        &&

                    uuo.MatruskiIspitStavke
                        .OrderByDescending(mis => mis.Id)
                        .FirstOrDefault().Bodovi <= 50)
                //kraj zadataka 3b
                .ToHashSet();
            


            foreach (var upisUOdjeljenje in upisiUOdjeljenja)
            {
                upisUOdjeljenje.MatruskiIspitStavke.OrderByDescending(x => x.Id).FirstOrDefault();

                MatruskiIspitStavka matruskiIspitStavkaTemp = new MatruskiIspitStavka
                {
                    Oslobodjen = false,
                    MaturskiIspitId = noviMaturskiIspit.Id,
                    UpisUOdjeljenjeId = odjeljenjeId,
                    Bodovi = 0,
                };

                if(upisUOdjeljenje.OpciUspjeh == 5)
                {
                    matruskiIspitStavkaTemp.Oslobodjen = true;
                    matruskiIspitStavkaTemp.Bodovi = null;
                }


                _context.MaturskiIspitStavka.Add(matruskiIspitStavkaTemp);
            }
            _context.SaveChanges();

        }

        public DetaljiMaturskogIspitaVM DetaljiMaturskogIspita(int matriskiIspitId)
        {
            DetaljiMaturskogIspitaVM dmi = _context.MaturskiIspit
                .Where(mi => mi.Id == matriskiIspitId)
                .Select(mi => new DetaljiMaturskogIspitaVM
                {
                    MaturskogIspitId = mi.Id,
                    Datum = mi.Datum,
                    Ispitivac = mi.Nastavnik.ImePrezime,
                    Odjeljenje = mi.Odjeljenje.Naziv
                }).First();

            return dmi;
        }

        public HashSet<RezultatiIspitaRedVM> RezultatiIspita(int matriskiIspitId)
        {
            HashSet<RezultatiIspitaRedVM> ri = _context.MaturskiIspitStavka
                .Include(mis => mis.MaturskiIspit)
                .Include(mis => mis.MaturskiIspit.Nastavnik)
                .Include(mis => mis.UpisUOdjeljenje)
                .Include(mis => mis.UpisUOdjeljenje.Ucenik)
                .Where(mis => mis.MaturskiIspitId == matriskiIspitId
                && mis.MaturskiIspit.NastavnikId == _nastavnikId)
                .Select(mis => new RezultatiIspitaRedVM
                {
                    MaturskiIspitStavkaId = mis.Id,
                    Bodovi = mis.Bodovi ?? 0,
                    OpciUspjehUcenika = mis.UpisUOdjeljenje.OpciUspjeh,
                    Oslobodjen = mis.Oslobodjen,
                    UcenikIme = mis.UpisUOdjeljenje.Ucenik.ImePrezime,
                    UcenikPrezime = mis.UpisUOdjeljenje.Ucenik.ImePrezime,
                }).ToHashSet();

            return ri;
        }

        public RezultatiIspitaRedVM DetaljiMaturskiIspitStavka(int maturskiIspitStavkaId)
        {
            RezultatiIspitaRedVM ri = _context.MaturskiIspitStavka
                .Include(mis => mis.UpisUOdjeljenje)
                .Include(mis => mis.UpisUOdjeljenje.Ucenik)
                .Where(mis => mis.Id == maturskiIspitStavkaId)
                .Select(mis => new RezultatiIspitaRedVM
                {
                    MaturskiIspitStavkaId = mis.Id,
                    Bodovi = mis.Bodovi ?? 0,
                    Oslobodjen = mis.Oslobodjen,
                    UcenikIme = mis.UpisUOdjeljenje.Ucenik.ImePrezime,
                    UcenikPrezime = mis.UpisUOdjeljenje.Ucenik.ImePrezime,
                    OpciUspjehUcenika = mis.UpisUOdjeljenje.OpciUspjeh
                }).First();

            return ri;
        }

        public MatruskiIspitStavka AzurirajMaturskiIspitStavka(int maturskiIspitStavkaId, int bodovi)
        {
            MatruskiIspitStavka maturskiIspitStavka = _context.MaturskiIspitStavka
                .Where(mis => mis.Id == maturskiIspitStavkaId)
                .First();

            if(!maturskiIspitStavka.Oslobodjen)
            {
                maturskiIspitStavka.Bodovi = bodovi;
                _context.MaturskiIspitStavka.Update(maturskiIspitStavka);
                _context.SaveChanges();
            }
            return maturskiIspitStavka;
        }

        public MatruskiIspitStavka OslobodljenMaturskiIspitStavka(int maturskiIspitStavkaId)
        {
            MatruskiIspitStavka maturskiIspitStavka = _context.MaturskiIspitStavka
                .Where(mis => mis.Id == maturskiIspitStavkaId)
                .First();

            maturskiIspitStavka.Oslobodjen = true;
            maturskiIspitStavka.Bodovi = null;

            _context.MaturskiIspitStavka.Update(maturskiIspitStavka);
            _context.SaveChanges();

            return maturskiIspitStavka;
        }
    }
}
