using System;
using System.Collections.Generic;

namespace Eindproject_BePact.Models
{
    public class Bedrijf
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoonnr { get; set; }

        public virtual ICollection<Persoon> Personen { get; set; }
    }
}