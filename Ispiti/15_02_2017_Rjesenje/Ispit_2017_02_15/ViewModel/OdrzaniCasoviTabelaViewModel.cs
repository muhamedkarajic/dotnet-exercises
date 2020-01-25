using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModel
{
    public class OdrzaniCasoviTabelaViewModel
    {
        public int NastavnikId { get; set; }
        public string ImePrezimeNastavnika { get; set; }
        public HashSet<OdrzaniCasoviRedViewModel> OdrzaniCasRed { get; set; }
        public List<SelectListItem> AkGodPredmeti { get; set; }
    }
}
