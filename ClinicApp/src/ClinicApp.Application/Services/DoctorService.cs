using ClinicApp.Application.DTOs;
using ClinicApp.Application.Interfaces;
using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Interfaces;

namespace ClinicApp.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repo;

    public DoctorService(IDoctorRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<DoctorDto>> GetAllAsync()
    {
        var doctors = await _repo.GetAllAsync();
        return doctors.Select(MapToDto);
    }

    public async Task<DoctorDto?> GetByIdAsync(int id)
    {
        var doctor = await _repo.GetByIdAsync(id);
        return doctor is null ? null : MapToDto(doctor);
    }

    public async Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization)
    {
        var doctors = await _repo.GetBySpecializationAsync(specialization);
        return doctors.Select(MapToDto);
    }

    public async Task<IEnumerable<DoctorDto>> GetAvailableDoctorsAsync()
    {
        var doctors = await _repo.GetAvailableDoctorsAsync();
        return doctors.Select(MapToDto);
    }

    public async Task<DoctorDto> CreateAsync(CreateDoctorDto dto)
    {
        var doctor = new Doctor
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Specialization = dto.Specialization,
            Phone = dto.Phone,
            Email = dto.Email
        };

        await _repo.AddAsync(doctor);
        await _repo.SaveChangesAsync();
        return MapToDto(doctor);
    }

    public async Task<DoctorDto?> UpdateAsync(int id, UpdateDoctorDto dto)
    {
        var doctor = await _repo.GetByIdAsync(id);
        if (doctor is null) return null;

        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Specialization = dto.Specialization;
        doctor.Phone = dto.Phone;
        doctor.Email = dto.Email;
        doctor.IsAvailable = dto.IsAvailable;
        doctor.UpdatedAt = DateTime.UtcNow;

        _repo.Update(doctor);
        await _repo.SaveChangesAsync();
        return MapToDto(doctor);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doctor = await _repo.GetByIdAsync(id);
        if (doctor is null) return false;

        _repo.Delete(doctor);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static DoctorDto MapToDto(Doctor d) => new()
    {
        Id = d.Id,
        FirstName = d.FirstName,
        LastName = d.LastName,
        Specialization = d.Specialization,
        Phone = d.Phone,
        Email = d.Email,
        IsAvailable = d.IsAvailable
    };
}
