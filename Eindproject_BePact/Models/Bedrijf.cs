using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eindproject_BePact.Models
{
    public class Bedrijf
    {
        public int ID { get; set; }
        [Required, StringLength(50, ErrorMessage = "Naam moet 2-50 karakters bevatten.", MinimumLength = 2)]
        public string Naam { get; set; }
        [Required, DataType(DataType.EmailAddress), StringLength(50, ErrorMessage = "Email moet 5-50 karakters bevatten.", MinimumLength = 5)]
        public string Email { get; set; }
        [Required, Display(Name = "Telefoonnummer"), StringLength(15, ErrorMessage = "Telefoonnummer moet 5-15 karakters bevatten.", MinimumLength = 5)]
        public string Telefoonnr { get; set; }

        public virtual ICollection<Persoon> Personen { get; set; }
    }
}