namespace Clinic.Shared.DTOs;

/// <summary>
/// DTO for appointment response
/// </summary>
public class AppointmentResponse
{
    /// <summary>Appointment identifier</summary>
    public Guid AppointmentId { get; set; }

    /// <summary>Patient identifier</summary>
    public Guid PatientId { get; set; }

    /// <summary>Clinic practitioner identifier</summary>
    public Guid ClinicPractitionerId { get; set; }

    /// <summary>Appointment date and time</summary>
    public DateTime AppointmentDateTime { get; set; }

    /// <summary>Service type</summary>
    public string ServiceType { get; set; } = string.Empty;

    /// <summary>Appointment status</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>Notes</summary>
    public string Notes { get; set; } = string.Empty;

    /// <summary>When the appointment was created</summary>
    public DateTime CreatedAt { get; set; }
}
