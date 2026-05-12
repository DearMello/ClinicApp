using ClinicApp.Domain.Entities;

namespace ClinicApp.Domain.Interfaces;

public interface IPatientRepository : IRepository<Patient>
{
    Task<Patient?> GetByEmailAsync(string email);
}
