using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eindproject_BePact.Models
{
    public class Persoon
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Voornaam moet 2-50 karakters bevatten.", MinimumLength = 2)]
        public string Voornaam { get; set; }
        [StringLength(50, ErrorMessage = "Achternaam moet 2-50 karakters bevatten.", MinimumLength = 2)]
        public string Achternaam { get; set; }
        [StringLength(50, ErrorMessage = "Email moet 5-50 karakters bevatten.", MinimumLength = 5)]
        public string Email { get; set; }
        [Display(Name = "Telefoonnummer"), StringLength(15, ErrorMessage = "Telefoonnummer moet 5-15 karakters bevatten.", MinimumLength = 5)]
        public string Telefoonnr { get; set; }
        public int? BedrijfID { get; set; }

        [Display(Name = "Naam")]
        public string Naam
        {
            get { return Voornaam + " " + Achternaam; }
        }

        public virtual Bedrijf Bedrijf { get; set; }
        public virtual ICollection<PersoonActiviteit> PersoonActiviteiten { get; set; }
    }
}