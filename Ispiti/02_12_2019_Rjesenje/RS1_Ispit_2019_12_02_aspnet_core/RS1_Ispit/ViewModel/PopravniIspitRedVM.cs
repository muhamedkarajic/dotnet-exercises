using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModel
{
    public class PopravniIspitRedVM
    {
        public int PopravniIspitId { get; set; }
        public DateTime DatumPopravnog { get; set; }
        public string NazivPredmet { get; set; }
        public int BrojUcenikaNaIspitu { get; set; }
        public int BrojUcenikaPolozili { get; set; }
    }
}
