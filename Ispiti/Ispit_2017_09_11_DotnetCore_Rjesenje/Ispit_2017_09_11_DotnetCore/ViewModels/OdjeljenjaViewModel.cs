using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjaViewModel
    {
        public HashSet<OdjeljenjaTabelaViewModel> OdjeljenjaTabela { get; set; }
        public HashSet<SelectListItem> Razrednici { get; set; }
        public HashSet<SelectListItem> Odjeljenja { get; set; }
        public NovoOdjeljenje NovoOdjeljenje { get; set; }

        public OdjeljenjaViewModel
        (
            HashSet<OdjeljenjaTabelaViewModel> odjeljenjaTabela,
            HashSet<SelectListItem> razrednici,
            HashSet<SelectListItem> odjeljenja
        )
        {
            OdjeljenjaTabela = odjeljenjaTabela;
            Razrednici = razrednici;
            Odjeljenja = odjeljenja;
            NovoOdjeljenje = new NovoOdjeljenje();
        }

        public OdjeljenjaViewModel() 
        { 
            NovoOdjeljenje = new NovoOdjeljenje();
        }
    }
}
