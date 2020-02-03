using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PrikazTakmicenjaRedVM
    {
        public int TakmicenjeId { get; set; }
        public string NazivPredmeta { get; set; }
        public int Razred { get; set; }
        public DateTime Datum { get; set; }
        public int BrojUcenikaNisuPristupili { get; set; }
        public string NajboljiUcenikSkola { get; set; }
        public string NajboljiUcenikOdjeljenje { get; set; }
        public string NajboljiUcenikImePrezime { get; set; }
    }
}
