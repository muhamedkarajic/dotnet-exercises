using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModel
{
    public class RezultatiIspitaRedVM
    {
        
        public int MaturskiIspitStavkaId { get; set; }
        public string UcenikIme { get; set; }
        public string UcenikPrezime { get; set; }
        public int OpciUspjehUcenika { get; set; }
        public float Bodovi { get; set; }
        public bool Oslobodjen { get; set; }
    }
}
