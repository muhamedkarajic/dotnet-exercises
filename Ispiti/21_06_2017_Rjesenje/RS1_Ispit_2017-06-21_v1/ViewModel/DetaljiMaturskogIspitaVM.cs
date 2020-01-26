using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModel
{
    public class DetaljiMaturskogIspitaVM
    {
        public int MaturskogIspitId { get; set; }
        public string Ispitivac { get; set; }
        public DateTime Datum { get; set; }
        public string Odjeljenje { get; set; }
    }
}
