namespace Eindproject_BePact.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Eindproject_BePact.DAL.BePactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Eindproject_BePact.DAL.BePactContext";
        }

        protected override void Seed(Eindproject_BePact.DAL.BePactContext context)
        {
            var bedrijven = new List<Bedrijf> {
                new Bedrijf { Naam="Bedrijf 1", Email="info@bedrijf1.be", Telefoonnr="015 12 34 56"},
                new Bedrijf { Naam="Bedrijf 2", Email="info@bedrijf2.be", Telefoonnr="015 23 45 67"},
                new Bedrijf { Naam="Bedrijf 3", Email="info@bedrijf3.be", Telefoonnr="015 34 56 78"},
            };

            bedrijven.ForEach(b => context.Bedrijven.AddOrUpdate(be => be.Naam, b));
            context.SaveChanges();

            var personen = new List<Persoon>
            {
                new Persoon { Voornaam="Persoon 1", Achternaam="Achternaam 1", Email="info@persoon1.be", Telefoonnr="0400 10 00 00", BedrijfID=1},
                new Persoon { Voornaam="Persoon 2", Achternaam="Achternaam 2", Email="info@persoon2.be", Telefoonnr="0400 20 00 00", BedrijfID=2},
                new Persoon { Voornaam="Persoon 3", Achternaam="Achternaam 3", Email="info@persoon3.be", Telefoonnr="0400 30 00 00", BedrijfID=3},
            };

            personen.ForEach(p => context.Personen.AddOrUpdate(s => new { s.Email, s.Telefoonnr }, p));
            context.SaveChanges();

            var activiteiten = new List<Activiteit>
            {
                new Activiteit { ActiviteitType=ActiviteitType.Les },
                new Activiteit { ActiviteitType=ActiviteitType.Workshop },
                new Activiteit { ActiviteitType=ActiviteitType.Feedback },
                new Activiteit { ActiviteitType=ActiviteitType.Gastlezing },
                new Activiteit { ActiviteitType=ActiviteitType.Advies },
                new Activiteit { ActiviteitType=ActiviteitType.Eindwerk },
                new Activiteit { ActiviteitType=ActiviteitType.Stage },
                new Activiteit { ActiviteitType=ActiviteitType.Andere },
            };

            activiteiten.ForEach(a => context.Activiteiten.AddOrUpdate(c => c.ActiviteitType, a));
            context.SaveChanges();

            var persoonActiviteiten = new List<PersoonActiviteit>
            {
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=1, Beschrijving="Beschrijving Les" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=2, Beschrijving="Beschrijving Workshop" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=3, Beschrijving="Beschrijving Feedback" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=4, Beschrijving="Beschrijving Gastlezing" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=5, Beschrijving="Beschrijving Avies" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=6, Beschrijving="Beschrijving Eindwerk" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=7, Beschrijving="Beschrijving Stage" },
                    new PersoonActiviteit { PersoonID=1, ActiviteitID=8, Beschrijving="Beschrijving Andere" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=1, Beschrijving="Beschrijving Les" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=2, Beschrijving="Beschrijving Workshop" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=3, Beschrijving="Beschrijving Feedback" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=4, Beschrijving="Beschrijving Gastlezing" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=5, Beschrijving="Beschrijving Avies" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=6, Beschrijving="Beschrijving Eindwerk" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=7, Beschrijving="Beschrijving Stage" },
                    new PersoonActiviteit { PersoonID=2, ActiviteitID=8, Beschrijving="Beschrijving Andere" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=1, Beschrijving="Beschrijving Les" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=2, Beschrijving="Beschrijving Workshop" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=3, Beschrijving="Beschrijving Feedback" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=4, Beschrijving="Beschrijving Gastlezing" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=5, Beschrijving="Beschrijving Avies" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=6, Beschrijving="Beschrijving Eindwerk" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=7, Beschrijving="Beschrijving Stage" },
                    new PersoonActiviteit { PersoonID=3, ActiviteitID=8, Beschrijving="Beschrijving Andere" },
                };

            persoonActiviteiten.ForEach(pa => context.PersoonActiviteiten.AddOrUpdate(pac => new { pac.PersoonID, pac.ActiviteitID }, pa));
            context.SaveChanges();
        }
    }
}
