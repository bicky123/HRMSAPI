using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class RentersRepository : Repository<Renters>, IRentersRepository
    {
        public RentersRepository(AppDbContext context) : base(context)
        {

        }
    }
}
