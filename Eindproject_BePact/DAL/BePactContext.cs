using Eindproject_BePact.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Eindproject_BePact.DAL
{
    public class BePactContext : DbContext
    {
        public BePactContext() : base("BePactContext") { }

        public DbSet<Persoon> Personen { get; set; }
        // DbSet<PersoonActiviteit> en DbSet<Activiteit> kunnen weggelaten worden.
        // Het Entity Framework zou deze impliciet includen 
        // Omdat de Persoon entiteit verwijst naar PersoonActiviteit,
        // en deze op zijn beurt naar Activiteit.
        public DbSet<PersoonActiviteit> PersoonActiviteiten { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}