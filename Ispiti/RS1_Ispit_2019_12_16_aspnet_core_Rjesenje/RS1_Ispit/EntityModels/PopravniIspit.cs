using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspit
    {
        public int Id { get; set; }

        public int NastavnikId1 { get; set; }
        public int NastavnikId2 { get; set; }
        public int NastavnikId3 { get; set; }

        public DateTime DatumIspita { get; set; }

        public Skola Skola { get; set; }
        public int SkolaId { get; set; }

        public SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaId { get; set; }

        public Predmet Predmet { get; set; }
        public int PredmetId { get; set; }

        public HashSet<PopravniIspitStavka> PopravniIspitStavke { get; set; }
    }
}
