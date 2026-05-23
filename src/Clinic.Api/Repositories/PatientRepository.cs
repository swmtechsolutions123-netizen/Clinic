namespace Clinic.Api.Repositories;

using Clinic.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Clinic.Api.Data;

/// <summary>
/// Repository for Patient entity operations
/// </summary>
public class PatientRepository : BaseRepository<Patient>
{
    /// <summary>
    /// Initializes a new instance of the PatientRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public PatientRepository(ClinicContext context) : base(context)
    {
    }

    /// <summary>Gets a patient by email</summary>
    public async Task<Patient?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
    }

    /// <summary>Checks if a patient with the given email exists</summary>
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbSet.AnyAsync(p => p.Email == email);
    }
}
