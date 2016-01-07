using System;
using System.Collections.Generic;

namespace Eindproject_BePact.Models
{
    public class Persoon
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Telefoonnr { get; set; }

        public virtual ICollection<PersoonActiviteit> PersoonActiviteiten { get; set; }
    }
}