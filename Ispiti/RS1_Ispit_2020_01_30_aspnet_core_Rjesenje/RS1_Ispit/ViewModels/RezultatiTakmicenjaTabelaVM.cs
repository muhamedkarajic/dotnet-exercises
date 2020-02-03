using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatiTakmicenjaTabelaVM
    {
        public int takmicenjeId { get; set; }
        public HashSet<RezultatiTakmicenjaRedVM> RezultatiTakmicenjaRedovi { get; set; }
        public string SkolaDomacin { get; set; }
        public string PredmetNaziv { get; set; }
        public int Razred { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucano { get; set; }
    }
}
