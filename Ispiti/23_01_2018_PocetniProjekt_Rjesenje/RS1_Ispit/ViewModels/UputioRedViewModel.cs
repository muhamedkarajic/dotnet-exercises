using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputioRedViewModel
    {
        public int Id { get; set; }
        public DateTime DatumUputnice { get; set; }
        public string InicjaliLjekara { get; set; }
        public string Pacijent { get; set; }
        public string VrstaPretrage { get; set; }
        public DateTime? DatumRezultata { get; set; }

        public UputioRedViewModel(int id, DateTime datumUputnice, string inicjaliLjekara, string pacijent, string vrstaPretrage, DateTime? datumRezultata)
        {
            Id = id;
            DatumUputnice = datumUputnice;
            InicjaliLjekara = inicjaliLjekara;
            Pacijent = pacijent;
            VrstaPretrage = vrstaPretrage;
            DatumRezultata = datumRezultata;
        }

        public UputioRedViewModel() { }
    }
}
