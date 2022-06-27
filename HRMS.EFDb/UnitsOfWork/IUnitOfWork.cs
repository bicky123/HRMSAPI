using HRMS.EFDb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRMS.EFDb.UnitsOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        ValueTask<int> SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        ValueTask<IDbContextTransaction> BeginTransactionAsync();
        AppDbContext DbContext { get; init; }
        string ConnectionString { get; init; }
        IOwnersRepository Owners { get; init; }
        IRentersRepository Renters { get; init; }
        IHousesRepository Houses { get; init; }
        IRenterHouseMappingsRepository RenterHouseMappings { get; init; }
        ICountryRepository Country { get; init; }
        IStateRepository State { get; init; }
    }
}
