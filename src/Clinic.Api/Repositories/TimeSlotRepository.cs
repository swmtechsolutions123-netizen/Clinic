namespace Clinic.Api.Repositories;

using Clinic.Shared.Models;
using Clinic.Api.Data;

/// <summary>
/// Repository for TimeSlot entity operations
/// </summary>
public class TimeSlotRepository : BaseRepository<TimeSlot>
{
    /// <summary>
    /// Initializes a new instance of the TimeSlotRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public TimeSlotRepository(ClinicContext context) : base(context)
    {
    }

    /// <summary>Gets available time slots for a clinic practitioner on a specific date</summary>
    public async Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync(Guid clinicPractitionerId, DateTime date)
    {
        var startOfDay = date.Date;
        var endOfDay = startOfDay.AddDays(1);

        return await Task.FromResult(_dbSet
            .Where(ts => ts.ClinicPractitionerId == clinicPractitionerId
                && ts.IsAvailable
                && ts.StartTime >= startOfDay
                && ts.StartTime < endOfDay)
            .OrderBy(ts => ts.StartTime)
            .ToList());
    }
}