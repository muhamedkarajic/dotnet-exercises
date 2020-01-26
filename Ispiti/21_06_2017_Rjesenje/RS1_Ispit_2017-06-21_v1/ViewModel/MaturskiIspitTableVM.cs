using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModel
{
    public class MaturskiIspitTableVM
    {
        public HashSet<MaturskiIspitRedVM> MaturskiIspitRedovi { get; set; }
        public string Ispitivac { get; set; }
        public int IspitivacId { get; set; }
        public List<SelectListItem> Odjeljenja { get; set; }
    }
}
