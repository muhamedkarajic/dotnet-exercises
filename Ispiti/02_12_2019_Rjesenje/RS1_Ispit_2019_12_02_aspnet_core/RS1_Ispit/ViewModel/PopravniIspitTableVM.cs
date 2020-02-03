using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModel
{
    public class PopravniIspitTableVM
    {
        public HashSet<PopravniIspitRedVM> PopravniIspitRedovi { get; set; }
        public int OdjeljenjeId { get; set; }

        public HashSet<SelectListItem> Predmeti { get; set; }
        public string NazivSkole { get; set; }
        public string SkolskaGodinaNaziv { get; set; }
        public string OznakaOdjeljenja { get; set; }
    }
}
