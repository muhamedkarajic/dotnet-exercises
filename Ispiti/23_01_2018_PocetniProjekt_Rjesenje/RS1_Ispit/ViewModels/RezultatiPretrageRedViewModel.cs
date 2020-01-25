using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatiPretrageRedViewModel
    {
        public int Id { get; set; }
        public string Pretraga { get; set; }
        public double? IzmjerenaVrijednost { get; set; }
        public string JMJ { get; set; }
    }
}
