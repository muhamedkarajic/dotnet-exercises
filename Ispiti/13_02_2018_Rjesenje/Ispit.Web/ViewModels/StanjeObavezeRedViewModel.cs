using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class StanjeObavezeRedViewModel
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float ProcenatRealizacijeObaveze { get; set; }
        public int NotifikacijaDanaPrije { get; set; }
        public bool NotifikacijeRekurizivno { get; set; }
    }
}
