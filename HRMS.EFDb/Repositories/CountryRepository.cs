using HRMS.EFDb.Domain;
using HRMS.EFDb.Repositories.Interfaces;

namespace HRMS.EFDb.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
