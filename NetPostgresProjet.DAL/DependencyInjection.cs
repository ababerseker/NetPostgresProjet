using Microsoft.Extensions.DependencyInjection;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Repositories;

namespace NetPostgresProjet.DAL
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services)
        {
            // Nouveaux repositories
            services.AddScoped<IChambresRepository, ChambresRepository>();
            services.AddScoped<IDossierPatientRepository, DossierPatientRepository>();
            services.AddScoped<IFactureRepository, FactureRepository>();
            services.AddScoped<IHospitalisationRepository, HospitalisationRepository>();
            services.AddScoped<IOrdonnanceRepository, OrdonnanceRepository>();

            return services;
        }
    }
}
