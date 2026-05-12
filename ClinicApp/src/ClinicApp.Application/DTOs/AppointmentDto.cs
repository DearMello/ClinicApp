using ClinicApp.Domain.Enums;

namespace ClinicApp.Application.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public string DoctorFullName { get; set; } = string.Empty;
    public string DoctorSpecialization { get; set; } = string.Empty;
    public int PatientId { get; set; }
    public string PatientFullName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; }
    public string StatusName => Status.ToString();
}

public class CreateAppointmentDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class UpdateAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; }
}
