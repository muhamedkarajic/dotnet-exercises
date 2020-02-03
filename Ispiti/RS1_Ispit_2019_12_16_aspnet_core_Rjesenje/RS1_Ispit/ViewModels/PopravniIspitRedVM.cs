using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitRedVM
    {
        public int PopravniIspitId { get; set; }
        public DateTime DatumIspita { get; set; }
        public string NastavnikImePrezime { get; set; }
        public int UceniciNaIspitu { get; set; }
        public int BrojProlaznosti { get; set; }
    }
}
