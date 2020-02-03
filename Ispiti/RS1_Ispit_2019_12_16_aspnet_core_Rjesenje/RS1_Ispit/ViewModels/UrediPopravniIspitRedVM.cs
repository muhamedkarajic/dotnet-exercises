using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UrediPopravniIspitRedVM
    {
        public int PopravniIspitStavkaId { get; set; }

        public string UcenikImePrezime { get; set; }
        public string OdjeljenjeOznaka { get; set; }
        public int BrojUDnevniku { get; set; }
        public bool Prisutan { get; set; }
        public double? Bodovi { get; set; }
    }
}
