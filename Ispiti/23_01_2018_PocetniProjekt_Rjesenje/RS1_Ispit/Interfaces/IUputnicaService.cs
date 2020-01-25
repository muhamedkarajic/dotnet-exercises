using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Interfaces
{
    public interface IUputnicaService
    {
        RezultatPretrage RezultatPretrageUpdate(RezultatPretrageUpdateViewModel rezultatPretrage);
        RezultatPretrageUrediViewModel RezultatPretrage(int rezultatPretrageId);
        void ZakljucajUputnicu(int uputnicaId);
        DetaljiUputniceViewModel DetaljiUputnice(int uputnicaId);
        void DodajUputnica(NovaUputnicaViewModel uputnica);
        UputnicaPageViewModel GetUputnicaPage();
    }
}
