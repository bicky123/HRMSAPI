using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class RenterHouseMappingsRepository : Repository<RenterHouseMappings>, IRenterHouseMappingsRepository
    {
        public RenterHouseMappingsRepository(AppDbContext context) : base(context)
        {

        }
    }
}
