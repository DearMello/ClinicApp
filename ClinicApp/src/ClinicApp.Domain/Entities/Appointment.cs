using ClinicApp.Domain.Enums;

namespace ClinicApp.Domain.Entities;

public class Appointment : BaseEntity
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
}
