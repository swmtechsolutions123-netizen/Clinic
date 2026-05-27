namespace Clinic.Api.Repositories;

using Clinic.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Clinic.Api.Data;

/// <summary>
/// Repository for Appointment entity operations
/// </summary>
public class AppointmentRepository : BaseRepository<Appointment>
{
    /// <summary>
    /// Initializes a new instance of the AppointmentRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public AppointmentRepository(ClinicContext context) : base(context)
    {
    }

    /// <summary>Gets appointments for a specific patient</summary>
    public async Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(Guid patientId)
    {
        return await _dbSet
            .Where(a => a.PatientId == patientId)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    /// <summary>Gets appointments for a specific clinic practitioner</summary>
    public async Task<IEnumerable<Appointment>> GetClinicPractitionerAppointmentsAsync(Guid clinicPractitionerId)
    {
        return await _dbSet
            .Where(a => a.ClinicPractitionerId == clinicPractitionerId)
            .OrderBy(a => a.CreatedAt)
            .ToListAsync();
    }

    /// <summary>Checks if a time slot is already booked</summary>
    public async Task<bool> IsTimeSlotBookedAsync(Guid timeSlotId, Guid clinicPractitionerId)
    {
        return await _dbSet
            .AnyAsync(a => a.TimeSlotId == timeSlotId 
                && a.ClinicPractitionerId == clinicPractitionerId
                && a.Status != Clinic.Shared.Enums.AppointmentStatus.Cancelled);
    }
}