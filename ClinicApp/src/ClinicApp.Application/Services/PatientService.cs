using ClinicApp.Application.DTOs;
using ClinicApp.Application.Interfaces;
using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Interfaces;

namespace ClinicApp.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repo;

    public PatientService(IPatientRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
        var patients = await _repo.GetAllAsync();
        return patients.Select(MapToDto);
    }

    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        var patient = await _repo.GetByIdAsync(id);
        return patient is null ? null : MapToDto(patient);
    }

    public async Task<PatientDto?> GetByEmailAsync(string email)
    {
        var patient = await _repo.GetByEmailAsync(email);
        return patient is null ? null : MapToDto(patient);
    }

    public async Task<PatientDto> CreateAsync(CreatePatientDto dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Phone = dto.Phone,
            Email = dto.Email,
            Address = dto.Address
        };

        await _repo.AddAsync(patient);
        await _repo.SaveChangesAsync();
        return MapToDto(patient);
    }

    public async Task<PatientDto?> UpdateAsync(int id, UpdatePatientDto dto)
    {
        var patient = await _repo.GetByIdAsync(id);
        if (patient is null) return null;

        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.Phone = dto.Phone;
        patient.Email = dto.Email;
        patient.Address = dto.Address;
        patient.UpdatedAt = DateTime.UtcNow;

        _repo.Update(patient);
        await _repo.SaveChangesAsync();
        return MapToDto(patient);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _repo.GetByIdAsync(id);
        if (patient is null) return false;

        _repo.Delete(patient);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static PatientDto MapToDto(Patient p) => new()
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        DateOfBirth = p.DateOfBirth,
        Phone = p.Phone,
        Email = p.Email,
        Address = p.Address
    };
}
