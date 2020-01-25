using Ispit_2017_02_15.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Interfaces
{
    public interface IOdjeljenjeServices
    {
        OdrzaniCasoviTabelaViewModel OdrzaniCasoviTabela(int nastavnikId);
        void DodajNoviCas(NoviCasViewModel cas);
        HashSet<OdrzaniCasDetaljiTabelaViewModel> OdrzaniCasDetalji(int odrzanCasId);
    }
}
