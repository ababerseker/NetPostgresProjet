using Microsoft.Extensions.DependencyInjection;

namespace NetPostgresProjet.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            // Nous ajouterons les implémentations de services plus tard
            // services.AddScoped<IPatientService, PatientService>();
            // services.AddScoped<IEmployeService, EmployeService>();
            
            return services;
        }
    }
}
