using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UrediPopravniIspitTabelaVM
    {
        public int PopravniIspitId { get; set; }

        public int SkolaId { get; set; }
        public string SkolaNaziv { get; set; }
        public int PredmetId { get; set; }
        public string PredmetNaziv { get; set; }
        public int SkolskaGodinaId { get; set; }
        public string SkolskaGodinaNaziv { get; set; }

        public int Nastavnik1Id { get; set; }
        public int Nastavnik2Id { get; set; }
        public int Nastavnik3Id { get; set; }

        public string Nastavnik1ImePrezime { get; set; }
        public string Nastavnik2ImePrezime { get; set; }
        public string Nastavnik3ImePrezime { get; set; }

        public DateTime Datum { get; set; }
        public HashSet<UrediPopravniIspitRedVM> UrediPopravniIspitRedVMs { get; set; }
    }
}
