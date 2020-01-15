using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class DogadajiRedViewModel
    {
        public int ID { get; set; }
        public DateTime DatumDogadjanja { get; set; }
        public string Nastavnik { get; set; }
        public string OpisDogadjaja { get; set; }
        public float BrojObaveza { get; set; }
        public string Naziv { get; set; }
        public int DogadjajID { get; set; }

        public DogadajiRedViewModel(int iD, DateTime datumDogadjanja, string nastavnik, string opisDogadjaja, float brojObaveza, int dogadjajID)
        {
            ID = iD;
            DatumDogadjanja = datumDogadjanja;
            Nastavnik = nastavnik;
            OpisDogadjaja = opisDogadjaja;
            BrojObaveza = brojObaveza;
            DogadjajID = dogadjajID;
        }

        public DogadajiRedViewModel() { }
    }
}
