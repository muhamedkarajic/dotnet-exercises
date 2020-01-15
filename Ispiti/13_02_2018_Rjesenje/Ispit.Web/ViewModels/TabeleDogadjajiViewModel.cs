using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class TabeleDogadjajiViewModel
    {
        public HashSet<DogadajiRedViewModel> OznaceniDogadjaji { get; set; }
        public HashSet<DogadajiRedViewModel> NeoznaceniDogadjaji { get; set; }
        public HashSet<Notifikacija> Notifikacije { get; set; }

        public TabeleDogadjajiViewModel(HashSet<DogadajiRedViewModel> oznaceniDogadjaji, HashSet<DogadajiRedViewModel> neoznaceniDogadjaji, HashSet<Notifikacija> notifikacije)
        {
            OznaceniDogadjaji = oznaceniDogadjaji;
            NeoznaceniDogadjaji = neoznaceniDogadjaji;
            Notifikacije = notifikacije;
        }
    }
}
