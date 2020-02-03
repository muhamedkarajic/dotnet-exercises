using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdabirVM
    {
        public HashSet<SelectListItem> SkolskeGodine { get; set; }
        public HashSet<SelectListItem> Skole { get; set; }
        public HashSet<SelectListItem> Predmeti { get; set; }
    }
}
