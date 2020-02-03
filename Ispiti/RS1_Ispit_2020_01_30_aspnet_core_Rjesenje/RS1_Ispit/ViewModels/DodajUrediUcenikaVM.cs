using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajUrediUcenikaVM
    {
        public int TakmicenjeId { get; set; }
        public int TakmicenjeUcenikId { get; set; }
        public double Bodovi { get; set; }
        public string UcenikImePrezime { get; set; }
        public HashSet<SelectListItem> Ucenici { get; set; }
    }
}
