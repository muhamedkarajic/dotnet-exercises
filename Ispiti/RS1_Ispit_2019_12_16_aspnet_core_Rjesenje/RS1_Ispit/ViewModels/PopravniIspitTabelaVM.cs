using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitTabelaVM
    {
        public HashSet<PopravniIspitRedVM> PopravniIspitRedVMs { get; set; }
        public HashSet<SelectListItem> Nastavnici { get; set; }
        
        public int SkolskaGodinaId { get; set; }
        public string SkolskaGodinaNaziv { get; set; }

        public string SkolaNaziv { get; set; }
        public int PredmetId { get; set; }
        
        public string PredmetNaziv { get; set; }
        public int SkolaId { get; set; }

    }
}
