using RS1_Ispit_asp.net_core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.Interfaces
{
    public interface IPopravniIspitServices
    {
        HashSet<OdjeljenjeRedVM> GetOdjeljenja();
        PopravniIspitTableVM GetPopravniIspiti(int odjeljenjeId);
        void DodajPopravniIspit(int odjeljenjeId, int predmetId, DateTime datumIspita);
        void UrediPopravniIspit(int popravniIspitId);
    }
}
