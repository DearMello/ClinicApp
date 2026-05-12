using ClinicApp.Domain.Entities;
using ClinicApp.Domain.Interfaces;
using ClinicApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Infrastructure.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(ClinicDbContext context) : base(context) { }

    public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId)
        => await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId)
        => await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.PatientId == patientId)
            .ToListAsync();

    public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        => await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.AppointmentDate.Date == date.Date)
            .ToListAsync();

    public async Task<Appointment?> GetWithDetailsAsync(int id)
        => await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == id);
}
