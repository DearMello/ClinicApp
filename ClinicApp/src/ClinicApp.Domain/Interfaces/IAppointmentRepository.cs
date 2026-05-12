using ClinicApp.Domain.Entities;

namespace ClinicApp.Domain.Interfaces;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId);
    Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId);
    Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date);
    Task<Appointment?> GetWithDetailsAsync(int id);
}
