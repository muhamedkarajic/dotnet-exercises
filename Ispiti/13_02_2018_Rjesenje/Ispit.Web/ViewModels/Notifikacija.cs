using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class Notifikacija
    {
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public int PoslataNotifikacijaId { get; set; }

        public Notifikacija() { }

        public Notifikacija(string naziv, DateTime datum, string opis, int poslataNotifikacijaId)
        {
            Naziv = naziv;
            Datum = datum;
            Opis = opis;
            PoslataNotifikacijaId = poslataNotifikacijaId;
        }
    }
}
