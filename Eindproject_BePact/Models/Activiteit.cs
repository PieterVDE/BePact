using System;
using System.Collections.Generic;

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
        public ActiviteitType ActiviteitType { get; set; }

        public virtual ICollection<PersoonActiviteit> PersoonActiviteiten { get; set; }
    }
}