using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Interfaces;
using ClinicApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Infrastructure.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(ClinicDbContext context) : base(context) { }

    public async Task<Patient?> GetByEmailAsync(string email)
        => await _context.Patients
            .FirstOrDefaultAsync(p => p.Email.ToLower() == email.ToLower());
}
