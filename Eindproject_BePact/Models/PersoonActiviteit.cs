using System;
using System.Collections.Generic;

namespace Eindproject_BePact.Models
{
    public class PersoonActiviteit
    {
        public int ID { get; set; }
        public int PersoonID { get; set; }
        public int ActiviteitID { get; set; }
        public string Beschrijving { get; set; }

        public virtual Persoon Persoon { get; set; }
        public virtual Activiteit Activiteit { get; set; }
    }
}
