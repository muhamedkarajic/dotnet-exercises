using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DetaljiUputniceViewModel
    {
        public int Id { get; set; }
        public DateTime DatumUputnice { get; set; }
        public string Pacijent { get; set; }
        public DateTime? DatumRezultata { get; set; }
        public bool IsGotovNalaz { get; set; }
        public HashSet<RezultatiPretrageRedViewModel> RezultatiPretragaRedovi { get; set; }
    }
}
