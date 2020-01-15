using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class DetaljiDogadjajaViewModel
    {
        public int ID { get; set; }
        public DateTime DatumOdrzavanja { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string Opis { get; set; }
        public string Nastavnik { get; set; }
    }
}
