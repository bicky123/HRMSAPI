using HRMS.EFDb.Repositories;
using HRMS.EFDb.Repositories.Interfaces;
using HRMS.EFDb.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.EFDb.Extension
{
    public static class Extension
    {
        public static IServiceCollection AddEfSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //Entity FrameWork Setup
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("HRMS.EFDb")));
            return services;
        }

        public static IServiceCollection AddEfInject(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IDapper, DapperContext>();

            services.AddScoped<IOwnersRepository, OwnersRepository>();
            services.AddScoped<IHousesRepository, HousesRepository>();
            services.AddScoped<IRentersRepository, RentersRepository>();
            services.AddScoped<IRenterHouseMappingsRepository, RenterHouseMappingsRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();

            return services;
        }
    }
}
