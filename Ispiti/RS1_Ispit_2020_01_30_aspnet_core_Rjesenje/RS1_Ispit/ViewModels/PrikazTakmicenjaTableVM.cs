using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PrikazTakmicenjaTableVM
    {
        public List<PrikazTakmicenjaRedVM> PrikazTakmicenjaRedovi { get; set; }
        public string SkolaNaziv { get; set; }
        public int SkolaId { get; set; }
        public int Razred { get; set; }
        public HashSet<SelectListItem> Predmeti { get; set; }

    }
}
