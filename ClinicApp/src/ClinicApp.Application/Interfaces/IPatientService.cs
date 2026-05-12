using ClinicApp.Application.DTOs;

namespace ClinicApp.Application.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(int id);
    Task<PatientDto?> GetByEmailAsync(string email);
    Task<PatientDto> CreateAsync(CreatePatientDto dto);
    Task<PatientDto?> UpdateAsync(int id, UpdatePatientDto dto);
    Task<bool> DeleteAsync(int id);
}
