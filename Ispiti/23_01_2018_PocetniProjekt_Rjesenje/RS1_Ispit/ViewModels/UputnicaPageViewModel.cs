using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaPageViewModel
    {
        public HashSet<UputioRedViewModel> UputniceRedovi { get; set; }
        public HashSet<SelectListItem> Ljekari { get; set; }
        public HashSet<SelectListItem> Pacijenti { get; set; }
        public HashSet<SelectListItem> VrstePretraga { get; set; }
    }
}
