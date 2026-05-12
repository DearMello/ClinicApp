using ClinicApp.Application.DTOs;
using ClinicApp.Application.Interfaces;
using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Enums;
using ClinicApp.Domain.Interfaces;

namespace ClinicApp.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repo;

    public AppointmentService(IAppointmentRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(MapToDto);
    }

    public async Task<AppointmentDto?> GetByIdAsync(int id)
    {
        var item = await _repo.GetWithDetailsAsync(id);
        return item is null ? null : MapToDto(item);
    }

    public async Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(int doctorId)
    {
        var list = await _repo.GetByDoctorIdAsync(doctorId);
        return list.Select(MapToDto);
    }

    public async Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(int patientId)
    {
        var list = await _repo.GetByPatientIdAsync(patientId);
        return list.Select(MapToDto);
    }

    public async Task<IEnumerable<AppointmentDto>> GetByDateAsync(DateTime date)
    {
        var list = await _repo.GetByDateAsync(date);
        return list.Select(MapToDto);
    }

    public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto)
    {
        var appointment = new Appointment
        {
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId,
            AppointmentDate = dto.AppointmentDate,
            Notes = dto.Notes,
            Status = AppointmentStatus.Pending
        };

        await _repo.AddAsync(appointment);
        await _repo.SaveChangesAsync();
        return MapToDto(appointment);
    }

    public async Task<AppointmentDto?> UpdateAsync(int id, UpdateAppointmentDto dto)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment is null) return null;

        appointment.AppointmentDate = dto.AppointmentDate;
        appointment.Notes = dto.Notes;
        appointment.Status = dto.Status;
        appointment.UpdatedAt = DateTime.UtcNow;

        _repo.Update(appointment);
        await _repo.SaveChangesAsync();
        return MapToDto(appointment);
    }

    public async Task<bool> CancelAsync(int id)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment is null) return false;

        appointment.Status = AppointmentStatus.Cancelled;
        appointment.UpdatedAt = DateTime.UtcNow;
        _repo.Update(appointment);
        await _repo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment is null) return false;

        _repo.Delete(appointment);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static AppointmentDto MapToDto(Appointment a) => new()
    {
        Id = a.Id,
        DoctorId = a.DoctorId,
        DoctorFullName = a.Doctor is not null ? $"{a.Doctor.FirstName} {a.Doctor.LastName}" : string.Empty,
        DoctorSpecialization = a.Doctor?.Specialization ?? string.Empty,
        PatientId = a.PatientId,
        PatientFullName = a.Patient is not null ? $"{a.Patient.FirstName} {a.Patient.LastName}" : string.Empty,
        AppointmentDate = a.AppointmentDate,
        Notes = a.Notes,
        Status = a.Status
    };
}
