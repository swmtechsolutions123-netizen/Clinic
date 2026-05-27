namespace Clinic.Api.Repositories;

using Clinic.Shared.Models;
using Clinic.Api.Data;

/// <summary>
/// Repository for Clinic entity operations
/// </summary>
public class ClinicRepository : BaseRepository<Clinic>
{
    /// <summary>
    /// Initializes a new instance of the ClinicRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ClinicRepository(ClinicContext context) : base(context)
    {
    }

    /// <summary>Gets a clinic by name</summary>
    public async Task<Clinic?> GetByNameAsync(string name)
    {
        return await Task.FromResult(_dbSet.FirstOrDefault(c => c.Name == name));
    }
}