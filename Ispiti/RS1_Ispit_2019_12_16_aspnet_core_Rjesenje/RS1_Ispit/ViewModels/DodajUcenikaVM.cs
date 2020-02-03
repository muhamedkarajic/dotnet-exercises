using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajUcenikaVM
    {
        public HashSet<SelectListItem> Ucenici { get; set; }
        public int PopravniIspitId { get; set; }
    }
}
