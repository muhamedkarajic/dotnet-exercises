using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class DetaljiDogadjajaParentViewModel
    {
        public DetaljiDogadjajaViewModel DetaljiDogadjaja { get; set; }
        public HashSet<StanjeObavezeRedViewModel> StanjeObaveze { get; set; }

        public DetaljiDogadjajaParentViewModel(DetaljiDogadjajaViewModel detaljiDogadjaja, HashSet<StanjeObavezeRedViewModel> stanjeObaveze)
        {
            DetaljiDogadjaja = detaljiDogadjaja;
            StanjeObaveze = stanjeObaveze;
        }

        public DetaljiDogadjajaParentViewModel() { }
    }
}
