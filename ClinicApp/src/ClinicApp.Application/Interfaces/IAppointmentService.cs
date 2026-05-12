using ClinicApp.Application.DTOs;

namespace ClinicApp.Application.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAsync();
    Task<AppointmentDto?> GetByIdAsync(int id);
    Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(int doctorId);
    Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(int patientId);
    Task<IEnumerable<AppointmentDto>> GetByDateAsync(DateTime date);
    Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);
    Task<AppointmentDto?> UpdateAsync(int id, UpdateAppointmentDto dto);
    Task<bool> CancelAsync(int id);
    Task<bool> DeleteAsync(int id);
}
