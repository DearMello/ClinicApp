using ClinicApp.Domain.Entities;

namespace ClinicApp.Domain.Interfaces;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
    Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync();
}
