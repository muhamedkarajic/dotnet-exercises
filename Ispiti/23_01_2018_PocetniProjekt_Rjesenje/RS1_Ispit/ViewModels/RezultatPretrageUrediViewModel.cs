using Microsoft.AspNetCore.Mvc.Rendering;
using RS1.Ispit.Web.Models;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatPretrageUrediViewModel
    {
        public int Id { get; set; }
        public string Pretraga { get; set; }
        public VrstaVrijednosti VrstaVr { get; set; }
        public string MjernaJedinica { get; set; }
        public int UputnicaId { get; set; }

        public double? Vrijednost { get; set; }
        public HashSet<SelectListItem> Vrijednosti { get; set; }

        public RezultatPretrageUrediViewModel(int id, string pretraga, HashSet<SelectListItem> vrijednosti)
        {
            Id = id;
            Pretraga = pretraga;
            VrstaVr = VrstaVrijednosti.Modalitet;
            Vrijednosti = vrijednosti;

        }

        public RezultatPretrageUrediViewModel(int id, string pretraga, double? vrijednost, string mjernaJedinica)
        {
            Id = id;
            Pretraga = pretraga;
            VrstaVr = VrstaVrijednosti.NumerickaVrijednost;
            Vrijednost = vrijednost;
            MjernaJedinica = mjernaJedinica;
        }

        public RezultatPretrageUrediViewModel()
        {
        }
    }
}
