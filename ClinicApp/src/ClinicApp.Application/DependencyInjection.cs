using ClinicApp.Application.Interfaces;
using ClinicApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        return services;
    }
}
