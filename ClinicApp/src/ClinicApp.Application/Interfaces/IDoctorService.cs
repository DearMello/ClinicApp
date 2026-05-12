using ClinicApp.Application.DTOs;

namespace ClinicApp.Application.Interfaces;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllAsync();
    Task<DoctorDto?> GetByIdAsync(int id);
    Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization);
    Task<IEnumerable<DoctorDto>> GetAvailableDoctorsAsync();
    Task<DoctorDto> CreateAsync(CreateDoctorDto dto);
    Task<DoctorDto?> UpdateAsync(int id, UpdateDoctorDto dto);
    Task<bool> DeleteAsync(int id);
}
