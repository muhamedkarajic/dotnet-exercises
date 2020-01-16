using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjaTabelaViewModel
    {
        public OdjeljenjaTabelaViewModel
        (
            int id,
            string skolskaGodina,
            int razred,
            string oznaka,
            string razrednik,
            bool prebaceniUViseOdjeljenja,
            double prosjekOcjena,
            double najboljiUcenik
        )
        {
            Id = id;
            SkolskaGodina = skolskaGodina;
            Razred = razred;
            Oznaka = oznaka;
            Razrednik = razrednik;
            PrebaceniUViseOdjeljenja = prebaceniUViseOdjeljenja;
            ProsjekOcjena = prosjekOcjena;
            NajboljiUcenik = najboljiUcenik;
        }

        public OdjeljenjaTabelaViewModel() {}

        public int Id { get; set; }
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Razrednik { get; set; }
        public bool PrebaceniUViseOdjeljenja { get; set; }
        public double ProsjekOcjena { get; set; }
        public double NajboljiUcenik { get; set; }
    }
}
