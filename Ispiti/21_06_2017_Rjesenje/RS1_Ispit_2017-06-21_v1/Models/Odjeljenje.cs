using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1_Ispit_2017_06_21_v1.Models;

namespace RS1_Ispit_2017_06_21_v1.Models
{
    public class Odjeljenje
    {
        public int Id { get; set; }

        public Nastavnik Nastavnik { get; set; }
        public int NastavnikId { get; set; }

        public List<MaturskiIspit> MaturskiIspiti { get; set; }

        public string Naziv { get; set; }
    }
}
