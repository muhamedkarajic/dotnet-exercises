using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatiTakmicenjaRedVM
    {
        public int TakmicenjeUcenikId { get; set; }
        public string Odjeljenje { get; set; }
        public int BrojUDnevniku { get; set; }
        public bool Pristupio { get; set; }
        public double Bodovi { get; set; }
    }
}
