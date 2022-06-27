using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class OwnersRepository : Repository<Owners>, IOwnersRepository
    {
        public OwnersRepository(AppDbContext context) : base(context)
        {

        }
    }
}
