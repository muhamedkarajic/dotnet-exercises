using RS1_Ispit_2017_06_21_v1.Models;
using RS1_Ispit_2017_06_21_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.Interfaces
{
    public interface IIspitiServices
    {
        MaturskiIspitTableVM GetMaturskiIspitiTable();
        void NoviMaturskiIspit(DateTime datum, int odjeljenjeId);
        DetaljiMaturskogIspitaVM DetaljiMaturskogIspita(int matriskiIspitId);
        RezultatiIspitaRedVM DetaljiMaturskiIspitStavka(int maturskiIspitStavkaId);
        HashSet<RezultatiIspitaRedVM> RezultatiIspita(int matriskiIspitId);
        MatruskiIspitStavka AzurirajMaturskiIspitStavka(int maturskiIspitStavkaId, int bodovi);
        MatruskiIspitStavka OslobodljenMaturskiIspitStavka(int maturskiIspitStavkaId);
    }
}
