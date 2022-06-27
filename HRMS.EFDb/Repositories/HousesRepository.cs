using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class HousesRepository : Repository<Houses>, IHousesRepository
    {
        public HousesRepository(AppDbContext context) : base(context)
        {

        }
    }
}
