namespace Clinic.Api.Data;

using Microsoft.EntityFrameworkCore;
using Clinic.Shared.Models;

/// <summary>
/// Database context for the Clinic Booking System
/// </summary>
public class ClinicContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the ClinicContext class
    /// </summary>
    /// <param name="options">The database context options</param>
    public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
    {
    }

    /// <summary>Patients database set</summary>
    public DbSet<Patient> Patients { get; set; }

    /// <summary>Clinics database set</summary>
    public DbSet<Clinic> Clinics { get; set; }

    /// <summary>Practitioners database set</summary>
    public DbSet<Practitioner> Practitioners { get; set; }

    /// <summary>Time slots database set</summary>
    public DbSet<TimeSlot> TimeSlots { get; set; }

    /// <summary>Appointments database set</summary>
    public DbSet<Appointment> Appointments { get; set; }

    /// <summary>
    /// Configures the database model
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Patient entity
        modelBuilder.Entity<Patient>()
            .HasKey(p => p.PatientId);

        modelBuilder.Entity<Patient>()
            .HasIndex(p => p.Email)
            .IsUnique();

        // Configure Clinic entity
        modelBuilder.Entity<Clinic>()
            .HasKey(c => c.ClinicId);

        // Configure Practitioner entity
        modelBuilder.Entity<Practitioner>()
            .HasKey(p => p.PractitionerId);

        // Configure TimeSlot entity
        modelBuilder.Entity<TimeSlot>()
            .HasKey(ts => ts.TimeSlotId);

        modelBuilder.Entity<TimeSlot>()
            .HasIndex(ts => ts.ClinicPractitionerId);

        // Configure Appointment entity
        modelBuilder.Entity<Appointment>()
            .HasKey(a => a.AppointmentId);

        modelBuilder.Entity<Appointment>()
            .HasIndex(a => a.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasIndex(a => a.ClinicPractitionerId);

        modelBuilder.Entity<Appointment>()
            .HasIndex(a => a.TimeSlotId);
    }
}
