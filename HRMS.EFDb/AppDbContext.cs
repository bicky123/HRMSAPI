using HRMS.EFDb.Domain;
using HRMS.EFDb.DomainConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.EFDb
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<RenterHouseMappings> RenterHouseMappings { get; set; }
        public virtual DbSet<Renters> Renters { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new HousesConfiguration());
            builder.ApplyConfiguration(new OwnersConfiguration());
            builder.ApplyConfiguration(new RenterHouseMappingsConfiguration());
            builder.ApplyConfiguration(new RentersConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());
        }
    }
}