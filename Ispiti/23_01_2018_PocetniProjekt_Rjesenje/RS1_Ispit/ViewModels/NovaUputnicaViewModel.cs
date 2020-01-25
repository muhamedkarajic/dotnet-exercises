using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class NovaUputnicaViewModel
    {
        public int ljekarId { get; set; }
        public string datumUputnice { get; set; }
        public int pacijentId { get; set; }
        public int vrstePretragaId { get; set; }
    }
}
