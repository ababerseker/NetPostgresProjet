using Microsoft.Extensions.DependencyInjection;
using NetPostgresProjet.BLL.Interfaces;
using NetPostgresProjet.BLL.Services;

namespace NetPostgresProjet.BLL
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            // Nouveaux services
            services.AddScoped<IChambresService, ChambresService>();
            services.AddScoped<IDossierPatientService, DossierPatientService>();
            services.AddScoped<IFactureService, FactureService>();
            services.AddScoped<IHospitalisationService, HospitalisationService>();
            services.AddScoped<IOrdonnanceService, OrdonnanceService>();

            return services;
        }
    }
}
