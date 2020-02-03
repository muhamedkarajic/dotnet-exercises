using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitDodajVM
    {
        public int PopravniIspitId { get; set; }

        public string Predmet { get; set; }
        public int Razred { get; set; }
        public DateTime Datum { get; set; }
        public int SkolaId { get; set; }
        public List<SelectListItem> Skola { get; set; }
        public int SkolskaGodinaId { get; set; }
        public List<SelectListItem> SkolskaGodina { get; set; }


    }
}
