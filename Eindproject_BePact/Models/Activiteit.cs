using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eindproject_BePact.Models
{
    public enum ActiviteitType
    {
        Les,
        Workshop,
        Feedback,
        Gastlezing,
        Advies,
        Eindwerk,
        Stage,
        Andere
    }

    public class Activiteit
    {
        public int ID { get; set; }
        [Index(IsUnique = true)]
        public ActiviteitType ActiviteitType { get; set; }

        public virtual ICollection<PersoonActiviteit> PersoonActiviteiten { get; set; }
    }
}