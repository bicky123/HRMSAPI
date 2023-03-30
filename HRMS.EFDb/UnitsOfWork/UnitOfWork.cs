using HRMS.EFDb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRMS.EFDb.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext DbContext { get; init; }
        public string? ConnectionString { get; init; }
        public IOwnersRepository Owners { get; init; }
        public IRentersRepository Renters { get; init; }
        public IHousesRepository Houses { get; init; }
        public IRenterHouseMappingsRepository RenterHouseMappings { get; init; }
        public ICountryRepository Country { get; init; }
        public IStateRepository State { get; init; }

        public UnitOfWork(
            AppDbContext context,
            IOwnersRepository owners,
            IRentersRepository renters,
            IHousesRepository houses,
            IRenterHouseMappingsRepository renterHouseMappings,
            ICountryRepository country,
            IStateRepository state
            )
        {
            DbContext = context;
            ConnectionString = context.Database.GetConnectionString();

            Owners = owners;
            Renters = renters;
            Houses = houses;
            RenterHouseMappings = renterHouseMappings;
            Country = country;
            State = state;
        }
        public int SaveChanges() =>
             DbContext.SaveChanges();

        public async ValueTask<int> SaveChangesAsync() =>
            await DbContext.SaveChangesAsync();

        public async ValueTask<IDbContextTransaction> BeginTransactionAsync() =>
            await DbContext.Database.BeginTransactionAsync();

        public IDbContextTransaction BeginTransaction() =>
            DbContext.Database.BeginTransaction();
    }
}
