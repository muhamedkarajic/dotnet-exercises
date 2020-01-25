using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModel
{
    public class OdrzaniCasoviRedViewModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int BrojPrisutnih { get; set; }
        public int BrojStudenata { get; set; }
        public string OpisAkademskeGodine { get; set; }
        public string NazivPredmeta { get; set; }
        public double ProsjecnaOcjena { get; set; }
    }
}
