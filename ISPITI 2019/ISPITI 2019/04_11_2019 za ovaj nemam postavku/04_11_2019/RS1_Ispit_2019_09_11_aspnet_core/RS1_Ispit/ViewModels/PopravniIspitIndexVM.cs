using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitIndexVM
    {
        public class Row
        {
            public int PredmetId { get; set; }
            public string Predmet { get; set; }
            public int Razred { get; set; }
        }
        public List<Row> Predmeti { get; set; }
    }
}
