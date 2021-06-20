using Microsoft.EntityFrameworkCore;
using Novabase.Domain.Entities;
using System.Linq;

namespace Novabase.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<IndicatorType> IndicatorTypes { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
         
            builder.Entity<Package>().HasMany(p => p.Checkpoints).WithOne(b => b.Package);

            var cascadeFKs = builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
        }
    }
}
