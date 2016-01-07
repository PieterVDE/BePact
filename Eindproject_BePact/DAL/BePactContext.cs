using Eindproject_BePact.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Eindproject_BePact.DAL
{
    public class BePactContext : DbContext
    {
        public BePactContext() : base("BePactContext") { }

        public DbSet<Bedrijf> Bedrijven { get; set; }
        // Onderstaande DbSets kunnen hier weggelaten worden,
        // het Entity Framework zou deze impliciet includen.
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<PersoonActiviteit> PersoonActiviteiten { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}