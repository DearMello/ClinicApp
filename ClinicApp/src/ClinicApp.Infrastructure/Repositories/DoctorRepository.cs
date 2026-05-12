using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Interfaces;
using ClinicApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Infrastructure.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ClinicDbContext context) : base(context) { }

    public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization)
        => await _context.Doctors
            .Where(d => d.Specialization.ToLower().Contains(specialization.ToLower()))
            .ToListAsync();

    public async Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync()
        => await _context.Doctors
            .Where(d => d.IsAvailable)
            .ToListAsync();
}
