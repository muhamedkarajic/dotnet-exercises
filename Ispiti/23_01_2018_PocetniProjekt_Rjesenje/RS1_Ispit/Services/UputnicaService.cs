using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.Helper;
using RS1_Ispit_asp.net_core.Interfaces;
using RS1_Ispit_asp.net_core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Services
{
    public class UputnicaService: IUputnicaService
    {

        private readonly MojContext _context;


        public UputnicaService(MojContext context)
        {
            _context = context;
        }

        public RezultatPretrage RezultatPretrageUpdate(RezultatPretrageUpdateViewModel rezultatPretrage)
        {
            RezultatPretrage rezultatPretrageNovi = _context.RezultatPretrage
                .Include(rp => rp.LabPretraga)
                .Where(rp => rp.Id == rezultatPretrage.Id)
                .First();

            if (rezultatPretrageNovi.LabPretraga.VrstaVr == VrstaVrijednosti.NumerickaVrijednost)
            {
                rezultatPretrageNovi.NumerickaVrijednost = rezultatPretrage.Vrijednost;
            }
            else
            {
                rezultatPretrageNovi.ModalitetId = rezultatPretrage.ModalitetId;
            }
            _context.RezultatPretrage.Update(rezultatPretrageNovi);
            _context.SaveChanges();

            return rezultatPretrageNovi;
        }

        public RezultatPretrageUrediViewModel RezultatPretrage(int rezultatPretrageId)
        {
            RezultatPretrage rezPret = _context.RezultatPretrage
                .Include(rp => rp.LabPretraga)
                .Where(rp => rp.Id == rezultatPretrageId)
                .First();

            if (rezPret.LabPretraga.VrstaVr == VrstaVrijednosti.NumerickaVrijednost)
                return new RezultatPretrageUrediViewModel(rezPret.Id, rezPret.LabPretraga.Naziv, rezPret.NumerickaVrijednost, rezPret.LabPretraga.MjernaJedinica);

            RezultatPretrageUrediViewModel rezultati = new RezultatPretrageUrediViewModel(rezPret.Id, rezPret.LabPretraga.Naziv,
                _context.Modalitet.Where(m => m.LabPretragaId == rezPret.LabPretragaId).Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Opis
                }).ToHashSet());

            SelectListItem selectListItem = rezultati.Vrijednosti.Where(x => x.Value == rezPret.ModalitetId.ToString()).FirstOrDefault();
            if (selectListItem != null)
            {
                selectListItem.Selected = true;
            }

            return rezultati;
        }

        public void ZakljucajUputnicu(int uputnicaId)
        {
            Uputnica uputnica = _context.Uputnica.Find(uputnicaId);
            uputnica.IsGotovNalaz = true;

            _context.Update(uputnica);
            _context.SaveChanges();
        }

        public DetaljiUputniceViewModel DetaljiUputnice(int uputnicaId)
        {
            DetaljiUputniceViewModel detaljiUputniceViewModel = _context.Uputnica
                .Where(u => u.Id == uputnicaId)
                .Include(u => u.Pacijent)
                .Select(u => new DetaljiUputniceViewModel
                {
                    Id = u.Id,
                    DatumUputnice = u.DatumUputnice,
                    IsGotovNalaz = u.IsGotovNalaz,
                    Pacijent = u.Pacijent.Ime.VratiInicijalImena(),
                    DatumRezultata = u.DatumRezultata,
                    RezultatiPretragaRedovi = _context.RezultatPretrage
                    .Include(rp => rp.LabPretraga)
                    .Where(rp => rp.UputnicaId == u.Id)
                    .Select(rp => new RezultatiPretrageRedViewModel
                    {
                        Id = rp.Id,
                        IzmjerenaVrijednost = rp.NumerickaVrijednost,
                        JMJ = rp.LabPretraga.MjernaJedinica,
                        Pretraga = rp.LabPretraga.Naziv
                    }).ToHashSet()
                }).First();

            return detaljiUputniceViewModel;
        }

        public void DodajUputnica(NovaUputnicaViewModel uputnica)
        {
            Uputnica novaUputnica = new Uputnica()
            {
                UputioLjekarId = uputnica.ljekarId,
                PacijentId = uputnica.pacijentId,
                DatumUputnice = DateTime.Parse(uputnica.datumUputnice),
                VrstaPretrageId = uputnica.vrstePretragaId
            };

            _context.Uputnica.Add(novaUputnica);
            _context.SaveChanges();

            //ZADATAK:
            //Prilikom spašavanja nove uputnice za vrstu pretrage x potrebno je:
            // -dodati zapise u tabelu RezultatiPretrage za svaku
            //  pretragu p koja pripada vrsti x.

            //KOMENTAR: kako vidim treba pokupiti listu pretraga koje se vrše za tu određenu vrstu, 
            //i onda na osnovu toga kreirati rezultate za tu uputnicu i tu vrstu pretrage
            HashSet<LabPretraga> labPretrage = _context.LabPretraga
               .Where(lp => lp.VrstaPretrageId == uputnica.vrstePretragaId)
               .ToHashSet();

            HashSet<RezultatPretrage> rezultatiPretraga = new HashSet<RezultatPretrage>();
            foreach (var labPretraga in labPretrage)
            {
                rezultatiPretraga.Add(new RezultatPretrage()
                {
                    LabPretragaId = labPretraga.Id,
                    UputnicaId = novaUputnica.Id,
                });
            }

            _context.RezultatPretrage.AddRange(rezultatiPretraga);
            _context.SaveChanges();
        }


        public UputnicaPageViewModel GetUputnicaPage()
        {
            UputnicaPageViewModel uputnicaController = new UputnicaPageViewModel();

            uputnicaController.UputniceRedovi = _context.Uputnica
                .Include(u => u.UputioLjekar)
                .Include(u => u.Pacijent)
                .Include(u => u.VrstaPretrage)
                .Select(u => new UputioRedViewModel
                (
                    u.Id,
                    u.DatumUputnice,
                    u.UputioLjekar.Ime.VratiInicijale(),
                    u.Pacijent.Ime.VratiInicijalImena(),
                    u.VrstaPretrage.Naziv,
                    u.DatumRezultata
                )
                { })
                .ToHashSet();

            uputnicaController.Ljekari = _context.Ljekar
                .OrderBy(l => l.Ime)
                .Select
                (l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Ime.VratiInicijale()
                }).ToHashSet();

            uputnicaController.VrstePretraga = _context.VrstaPretrage
                .OrderBy(vp => vp.Naziv)
                .Select(vp => new SelectListItem
                {
                    Value = vp.Id.ToString(),
                    Text = vp.Naziv
                }).ToHashSet();

            uputnicaController.Pacijenti = _context.Pacijent
                .OrderBy(p => p.Ime)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Ime.VratiInicijalImena()
                }).ToHashSet();

            return uputnicaController;
        }
    }
}
