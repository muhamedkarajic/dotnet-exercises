using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspit
    {
        public int Id { get; set; }

        [ForeignKey(nameof(PredmetID))]
        public virtual Predmet Predmet { get; set; }
        public int PredmetID { get; set; }


        [ForeignKey(nameof(OdjeljenjeID))]
        public virtual Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeID { get; set; }


        public DateTime DatumIspita { get; set; }

        public HashSet<PopravniIspitStavka> PopravniIspitStavke { get; set; }

    }
}
